using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entity;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Web;

namespace ShoppingList.Controllers
{
    public class SListController : Controller
    {
        SListManager slm = new SListManager(new EfSListDal());
        UserManager um = new UserManager(new EfUserDal());
        ShoppingListContext context= new ShoppingListContext();
        //UserValidator userValidator = new UserValidator();

        [Authorize]
        public ActionResult Index(int userId)

        {
            var userInfo = context.Users.Where(x => x.UserId == userId ).Select(y => y.UserId).FirstOrDefault();
            var contentvalues = slm.GetListByUser(userInfo);
            ViewBag.userId = userInfo;
            return View(contentvalues);

        }

        public ActionResult AddSList(int id)
        {
            List<SelectListItem> valueList = (from x in um.GetList() select new SelectListItem { Text = x.UserName, Value = x.UserId.ToString() }).ToList();
            ViewBag.vl = valueList;
            return View();
        }

        [HttpPost]
        public ActionResult AddSList(SList p)
        {
            var userinfo = context.Users.Where(x => x.UserId == p.UserId).FirstOrDefault();
            slm.SListAdd(p);
            return RedirectToAction("Index", "SList", new {userId= userinfo.UserId});
        }
    }
}
