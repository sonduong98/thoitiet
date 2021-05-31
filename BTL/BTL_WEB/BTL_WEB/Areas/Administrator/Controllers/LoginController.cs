using BTL_WEB.Constant;
using Entities;
using Microsoft.Owin.Security.Cookies;
using Models.Login;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BTL_WEB.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        public BTLEntities bTLEntities = new BTLEntities();
        // GET: Administrator/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            var data = bTLEntities.Users.FirstOrDefault(c => c.UserName == user.UserName && c.Password==user.Password);
            if(data != null)
            {
                //dung de check da dang nhap hay chua
                //bool val1 = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
                //FormsAuthentication.SetAuthCookie(user.UserName, false);
                // FormsAuthentication.RedirectFromLoginPage(user.UserName, true);
                //FormsAuthentication.SetAuthCookie(user.UserName, true);
                Session["UserID"] = user.Password.ToString(); ;
                Session["UserName"] = user.UserName.ToString();
                Session["Id"] = data.Id;
                if (user.RememberMe == true)
                {
                    Session["Remember"] ="true";
                }
                else
                {
                    Session["Remember"] = null;
                }
                
                return Redirect("/Administrator/Home/Index");
            }
            else
            {
                ViewBag.Message = "User or Password is incorect";
                return View("Index");
            }
            
        }

      
        public ActionResult Logout()
        {
            Session["UserID"] = null ;
            Session["UserName"] = null;
            return Redirect("/Administrator/Login/Index");
        }
    }
}