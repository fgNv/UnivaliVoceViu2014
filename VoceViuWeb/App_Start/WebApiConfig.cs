using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using VoceViuWeb.Filters;

namespace VoceViuWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterFilters(HttpConfiguration config)
        {
            config.Filters.Add(new ExceptionHandlerAttribute());
        }
    }
}
