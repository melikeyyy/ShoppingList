using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingList.Controllers
{
    public class CategoryController : Controller
    {

        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ShoppingListContext context = new ShoppingListContext();

        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            cm.CategoryAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var cValue = cm.GetByID(id);
            return View(cValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var catValue = cm.GetByID(id);
            cm.CategoryDelete(catValue);
            return RedirectToAction("Index");
        }

        public ActionResult ProductByCategory(int id)
        {
            var contentValues = pm.GetListByCategoryID(id);
            return View(contentValues);
        }
    }
}
