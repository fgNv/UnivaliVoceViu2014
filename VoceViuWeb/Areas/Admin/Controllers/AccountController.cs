using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Filters;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Admin.Controllers
{

    public class AccountController : Controller
    {
        public ViewResult Login()
        {
            return View();
        }
    }
}