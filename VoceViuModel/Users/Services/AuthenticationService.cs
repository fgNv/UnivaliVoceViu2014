using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Commands;
using VoceViuModel.Users.Exceptions;

namespace VoceViuModel.Users.Services
{
    public class AuthenticationService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IAdvertiserRepository _advertiserRepository;
        private readonly CryptographyService _cryptographyService;

        public string AUTHENTICATION_TYPE_ADMIN = "admin";
        public string AUTHENTICATION_TYPE_ADVERTISER = "advertiser";

        public AuthenticationService(IAdministratorRepository administratorRepository, IAdvertiserRepository advertiserRepository, CryptographyService cryptographyService)
        {
            _administratorRepository = administratorRepository;
            _advertiserRepository = advertiserRepository;
            _cryptographyService = cryptographyService;
        }

        public IPrincipal AuthenticateAdministrator(AuthenticateMessage message)
        {
            var administrator = _administratorRepository.Get(message.Username);

            if (administrator == null)
                throw new InvalidUsernameException();

            var encryptedProvidedPassword = _cryptographyService.Encrypt(message.Password);
            if (!administrator.Password.Equals(encryptedProvidedPassword))
                throw new InvalidPasswordException();

            return Authenticate(AUTHENTICATION_TYPE_ADMIN);
        }

        public IPrincipal AuthenticateAdvertiser(AuthenticateMessage message)
        {
            var advertiser = _advertiserRepository.Get(message.Username);

            if (advertiser == null)
                throw new InvalidUsernameException();

            var encryptedProvidedPassword = _cryptographyService.Encrypt(message.Password);
            if (!advertiser.Password.Equals(encryptedProvidedPassword))
                throw new InvalidPasswordException();

            return Authenticate(AUTHENTICATION_TYPE_ADVERTISER);
        }

        private IPrincipal Authenticate(string authenticationType)
        {
            var identity = new ClaimsIdentity(authenticationType);
            var principal = new GenericPrincipal(identity, new[] { authenticationType });
            Thread.CurrentPrincipal = principal;
            return principal;
        }
    }
}
