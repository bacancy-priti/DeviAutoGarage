using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webAppDevi.Models;
using webAppDevi.Common;
using System.Web.Security;

namespace webAppDevi.Controllers
{
    public class UserController : Controller
    {
        Services s = new Services();
        public ActionResult Login()
        {
            if (Request.Cookies["userLoggedIn"] != null)
            {
                return RedirectToAction("ViewBrand", "Brand");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User u = s.GetUserByUserNameOrEmailAndPassword(model.UserName, model.Password);
                if (u != null)
                {
                    HttpCookie userLoggedIn = new HttpCookie("userLoggedIn");
                    userLoggedIn.Value = model.UserName;
                    userLoggedIn.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(userLoggedIn);
                    return RedirectToAction("ViewBrand", "Brand");
                }
                else
                {
                    ViewBag.ErrorMessage = "Wrong Username/Email or Password.";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            if (Request.Cookies["userLoggedIn"] != null)
            {
                Response.Cookies["userLoggedIn"].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
