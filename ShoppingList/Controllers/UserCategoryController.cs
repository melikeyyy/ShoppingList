using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
    public class UserCategoryController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ShoppingListContext context = new ShoppingListContext();
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        public ActionResult ProductByCategory(int id)
        {
            var contentValues = pm.GetListByCategoryID(id);
            return View(contentValues);
        }
    }
}
