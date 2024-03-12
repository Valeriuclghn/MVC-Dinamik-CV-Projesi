using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.Kullaniciadi == p.Kullaniciadi && x.Şifre == p.Şifre);
            if(bilgi != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgi.Kullaniciadi, false);
                Session["Kullaniciadi"] = bilgi.Kullaniciadi.ToString();
                return RedirectToAction("Index", "Deneyim");
            }
            else 
            {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult LogOut() 
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}