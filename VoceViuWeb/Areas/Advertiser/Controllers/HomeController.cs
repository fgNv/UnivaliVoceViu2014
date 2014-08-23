using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Filters;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Advertisers.Controllers
{
    [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADVERTISER)]
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}