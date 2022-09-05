using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ShoppingList.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        RegisterManager userManager = new RegisterManager(new EfUserDal());
        SListManager slm = new SListManager(new EfSListDal());
        UserManager um = new UserManager(new EfUserDal());
        ShoppingListContext context = new ShoppingListContext();

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        //[HttpPost]
        
        //public ActionResult UserLogin(User p)
        //{
        //    ////var userinfo = context.Users.Where(x => x.UserName == UserName).Select(y => y.UserId).FirstOrDefault();
        //    //var userInfo = e.Users.FirstOrDefault(x => x.UserName == p.UserName && x.UserPassword == p.UserPassword);
        //    ////if (userInfo != null)
        //    ////{
        //    // //  FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
        //    ////    //Session["UserName"] = userInfo.UserName;
        //    ////    return RedirectToAction("Index", "SList");
        //    ////}
        //    ////else
        //    ////{
        //    ////    return RedirectToAction("UserLogin");
        //    ////}

        //    //if (userInfo != null)
        //    //{
        //    //    //FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
        //    //    //Session["UserName"] = userInfo.UserName;
        //    //    //HttpContext.Session.SetString("p");
        //    //    return RedirectToAction("Index", "SList");
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction("UserLogin");
        //    //}
           
        //    var userInfo = e.Users.FirstOrDefault(x => x.UserName == p.UserName && x.UserPassword == p.UserPassword);
        //    if (userInfo != null)
        //    {
        //        CookieAuthenticationDefaults.AuthenticationScheme(userInfo.UserName, false);
        //        //FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
        //        //Session["UserName"] = userInfo.UserName;
        //        return RedirectToAction("UserLogin");
        //    }
        //    else
        //    {
        //        return RedirectToAction("UserLogin");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> UserLogin(User user)
        {
            var userInfo = context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword);
            if (userInfo != null)
            {
                await HttpContext.SignOutAsync();

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "Normal"));
                //claims.Add(new Claim("Sehir", "İstanbul"));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "SList", new {userId = userInfo.UserId});
            }
            //else
            //{

            //}

            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("p");  
            return View("Index", "SList");
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User u)
        {
            RegisterValidator registerValidator = new RegisterValidator();
            ValidationResult results = registerValidator.Validate(u);
            if (results.IsValid)
            {
                userManager.UserAdd(u);
                return RedirectToAction("UserRegister", "Account");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }



        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.Name == p.Name && x.Password == p.Password);
            if (adminUserInfo != null)
            {
                //FormsAuthentication.SetAuthCookie(adminUserInfo.AdminName, false);
                //Session["AdminName"] = adminUserInfo.AdminName;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "AdminHomePage");
            }
            return View();
        }

        public ActionResult AdminLogOut()
        {
            //FormsAuthentication.SignOut();
            //Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
