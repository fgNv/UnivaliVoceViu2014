using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Security.Claims;
using VoceViuWeb.Services;

namespace VoceViuWeb.Helpers
{
    public static class RequestExtensions
    {
        public static string GetProfile(this HttpRequestBase request)
        {
            var owinContext = request.GetOwinContext();
            var identity = owinContext.Request.User.Identity as ClaimsIdentity;
            var profileClaim = identity.Claims.FirstOrDefault(c => c.Type == SignInService.PROFILE_TYPE_CLAIMS_KEY);
            return profileClaim.Value;
        }
    }
}