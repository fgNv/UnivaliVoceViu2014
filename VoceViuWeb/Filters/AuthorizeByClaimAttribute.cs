using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace VoceViuWeb.Filters
{
    public class AuthorizeByClaimAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private string _profileType;

        public AuthorizeByClaimAttribute(string profileType)
        {
            _profileType = profileType;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}

