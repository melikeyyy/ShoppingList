using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingList.Controllers
{
    public class UserProductController : Controller
    {

        SListManager slm = new SListManager(new EfSListDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        UserManager um = new UserManager(new EfUserDal());
        ShoppingListContext context = new ShoppingListContext();

        public ActionResult MyList(string p)
        {
            var userInfo = context.SList.Where(x => x.Name == p).Select(y => y.SListId).FirstOrDefault();
            var contentvalues = pm.GetListBySList(userInfo);
            return View(contentvalues);

        }

        public ActionResult GetAllProductByUser(string p)
        {
            var values = from x in context.Products select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.Name.Contains(p));
            }
            return View(values.ToList());
        }

        public ActionResult GetProducts(string key)
        {
            var test = pm.GetList();
            var products = pm.GetList().Where(a => a.Key == key || a.Name.Contains(key)).ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct(int userId )
        {
            var a = slm.GetList();
            List<SelectListItem> valueList = (from x in slm.GetList().Where(x=> x.UserId== userId).ToList() select new SelectListItem { Text = x.Name, Value = x.SListId.ToString() }).ToList();
            List<SelectListItem> valueProduct = (from x in pm.GetList().Distinct() select new SelectListItem { Text = x.Name, Value = x.Name.ToString() }).ToList();
            ViewBag.vlc = valueProduct;
            ViewBag.vl = valueList;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            var userinfo = context.SList.Where(x => x.SListId == p.SListId).FirstOrDefault();
            pm.ProductAdd(p);
            return RedirectToAction("MyList", "UserProduct", new { Name = userinfo.Name });
        }

        public ActionResult DeleteList(int id, int userId)
        {
            
            var listValue = slm.GetByID(id);
            slm.SListDelete(listValue);
            return RedirectToAction("Index", "Slist", new {userId = userId });
        }

        public ActionResult DeleteProduct(int id)
        {

            var listValue = pm.GetByID(id);
            pm.ProductDelete(listValue);
            return RedirectToAction("Index", "Slist");
        }
    }
}
