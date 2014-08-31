using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users;
using VoceViuModel.Users.Services;
using VoceViuWeb.Models.Authentication;
using VoceViuWeb.Models.Authentication.Implementations;
using VoceViuWeb.Services;
using VoceViuPersistence;
using VoceViuModel;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;

namespace VoceViuWeb.App_Start
{
    public class DependencyRegistration
    {
        public static void RegisterDependencies(Container container)
        {
            var webRequestLifeStyle = new WebRequestLifestyle();
            container.RegisterPersistenceDependencies(webRequestLifeStyle);
            container.RegisterModelDependencies(webRequestLifeStyle);

            container.Register<SignInService, SignInService>(webRequestLifeStyle);

            container.Register<UserManager<Administrator>, UserManager<Administrator>>(webRequestLifeStyle);
            container.Register<UserManager<Advertiser>, UserManager<Advertiser>>(webRequestLifeStyle);

            container.Register<IUserStore<Administrator>, AdministratorStore>(webRequestLifeStyle);
            container.Register<IUserStore<Advertiser>, AdvertiserStore>(webRequestLifeStyle);

            container.Register<IAuthenticationManager>(() => HttpContext.Current.GetOwinContext().Authentication, webRequestLifeStyle);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver( new SimpleInjectorDependencyResolver(container));
            //container.Verify();
        }
    }
}