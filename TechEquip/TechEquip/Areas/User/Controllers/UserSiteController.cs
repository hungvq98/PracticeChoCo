using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TechEquip.Areas.User.Controllers
{
    public class UserSiteController : Controller
    {
        // GET: User/UserSite
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        
    }
}