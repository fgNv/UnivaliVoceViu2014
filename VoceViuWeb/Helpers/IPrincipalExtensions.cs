using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using VoceViuWeb.Services;

namespace VoceViuWeb.Helpers
{
    public static class IPrincipalExtensions
    {
        public static bool IsAdmin(this IPrincipal user)
        {
            var identity = user.Identity as ClaimsIdentity;
            var profileType = identity.Claims.FirstOrDefault(c => c.Type == SignInService.PROFILE_TYPE_CLAIMS_KEY);

            return profileType.Value == SignInService.PROFILE_TYPE_ADMIN;
        }

        public static int GetUserId(this IPrincipal user)
        {
            var identity = user.Identity as ClaimsIdentity;
            var userId = identity.Claims.FirstOrDefault(c => c.Type == SignInService.USER_ID_CLAIMS_KEY);

            return Int32.Parse(userId.Value);
        }
    }
}