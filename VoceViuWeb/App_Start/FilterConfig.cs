using System.Web;
using System.Web.Mvc;
using VoceViuWeb.Filters;

namespace VoceViuWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
