using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingList.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        ShoppingListContext context = new ShoppingListContext();


        public ActionResult Index(int categoryId)
        {
            var productValues = pm.GetList().Where(a => a.CategoryId == categoryId).ToList();
            return View(productValues);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            pm.ProductAdd(p);
            return RedirectToAction("GetAllProduct", "Product");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList() select new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            var proValue = pm.GetByID(id);
            return View(proValue);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            pm.ProductUpdate(p);
            return RedirectToAction("GetAllProduct", "Product");
        }

        public ActionResult DeleteProduct(int id)
        {
            var productValue = pm.GetByID(id);
            pm.ProductDelete(productValue);
            return RedirectToAction("GetAllProduct", "Product");
        }

        public ActionResult GetAllProduct(string p)
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

        public ActionResult ProductByCategory(int id)
        {
            var contentValues = pm.GetListByCategoryID(id);
            return View(contentValues);
        }
    }
}
