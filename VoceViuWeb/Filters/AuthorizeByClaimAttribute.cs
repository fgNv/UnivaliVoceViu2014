using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using VoceViuWeb.Services;

namespace VoceViuWeb.Filters
{
    public class AuthorizeByClaimAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        private string[] _profileType;

        public AuthorizeByClaimAttribute(params string[] profileType)
        {
            _profileType = profileType;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated) { 
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var identity = user.Identity as ClaimsIdentity;
            if (identity == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var profileType = identity.Claims.FirstOrDefault(c => c.Type == SignInService.PROFILE_TYPE_CLAIMS_KEY);
            if (profileType == null) { 
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (!_profileType.Contains(profileType.Value))
                filterContext.Result = profileType.Value == SignInService.PROFILE_TYPE_ADMIN ? 
                    new RedirectResult("/Advertiser/Account/Login") :
                    new RedirectResult("/Admin/Account/Login");
        }
    }
}

