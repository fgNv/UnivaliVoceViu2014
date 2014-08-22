﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Filters;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Admin.Controllers
{
    [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN)]
    public class LocationsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

    }
}