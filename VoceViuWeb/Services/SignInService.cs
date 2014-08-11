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
            
            identity.AddClaim(new Claim("profileType","admin"));            
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public async Task SignInAdvertiserAsync(AdvertiserIdentity user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _advertiserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaim(new Claim("profileType", "advertiser"));
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }
    }
}