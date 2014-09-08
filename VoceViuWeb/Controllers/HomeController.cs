using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Helpers;

namespace VoceViuWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.User;

            if (user == null || user.Identity == null || !user.Identity.IsAuthenticated)
                return View();

            if (user.IsAdmin())
                return Redirect("/admin/home/index");

            return Redirect("/advertiser/home/index");
        }
    }
}