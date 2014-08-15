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
                filterContext.Result = new HttpUnauthorizedResult();

            var userClaims = user.Identity as ClaimsIdentity;
            if(userClaims == null)
                filterContext.Result = new HttpUnauthorizedResult();

            var profileType = userClaims.Claims.FirstOrDefault(c => c.Type == SignInService.PROFILE_TYPE_CLAIMS_KEY);
            if (profileType == null) { 
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (profileType.Value != _profileType)
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}

