using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BL;

namespace e_commerce.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        usersinfoManager manager = new usersinfoManager();
        // GET: Admin/Login
        public ActionResult Index()
        {

            
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string sifre)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifre))
            {
                TempData["Mesaj"] = "E-mail box and password cannot be emty.!";
            }
            else
            {
                var user = manager.Find(k => k.e_mail == email && k.password == sifre && k.situation == true);
                if (user != null)
                {
                    Session["admin"] = user;
                    FormsAuthentication.SetAuthCookie(user.user_name, true);
                    if (Request.QueryString["ReturnUrl"] == null) return Redirect("/Admin/Default"); 
                    else return Redirect(Request.QueryString["ReturnUrl"]);
                }
                else TempData["Mesaj"] = "Access Denied!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("admin");
            FormsAuthentication.SignOut();

            return Redirect("index");
        }
    }
}