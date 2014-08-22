using System.Web.Mvc;

namespace VoceViuWeb.Areas.Admin
{
    public class AdvertiserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Advertisers";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Advertiser_default",
                "Advertiser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "VoceViuWeb.Areas.Advertisers.Controllers" }
            );
        }
    }
}