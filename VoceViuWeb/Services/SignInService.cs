using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using VoceViuModel.Users;
using VoceViuWeb.Models.Authentication;

namespace VoceViuWeb.Services
{
    public class SignInService
    {
        public const string PROFILE_TYPE_CLAIMS_KEY = "profileType";
        public const string PROFILE_TYPE_ADMIN = "admin";
        public const string PROFILE_TYPE_ADVERTISER = "advertiser";

        private readonly IAuthenticationManager _authenticationManager;
        private readonly UserManager<AdministratorIdentity> _administratorManager;
        private readonly UserManager<AdvertiserIdentity> _advertiserManager;

        public SignInService(IAuthenticationManager authenticationManager, UserManager<AdministratorIdentity> administratorManager, UserManager<AdvertiserIdentity> advertiserManager)
        {
            _authenticationManager = authenticationManager;
            _administratorManager = administratorManager;
            _advertiserManager = advertiserManager;
        }

        public async Task SignInAdministratorAsync(AdministratorIdentity user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _administratorManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            identity.AddClaim(new Claim(PROFILE_TYPE_CLAIMS_KEY, PROFILE_TYPE_ADMIN));            
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public async Task SignInAdvertiserAsync(AdvertiserIdentity user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _advertiserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim(PROFILE_TYPE_CLAIMS_KEY, "advertiser"));
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}