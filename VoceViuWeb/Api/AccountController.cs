using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Commands;
using VoceViuModel.Users.Services;
using VoceViuWeb.Exceptions;
using VoceViuWeb.Models;
using VoceViuWeb.Models.Account;
using VoceViuWeb.Models.Authentication;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Admin.API
{
    public class AccountController : ApiController
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly SignInService _signInService;
        private readonly AdvertiserAccountService _advertiserAccountService;

        public AccountController(IAdministratorRepository administratorRepository, AuthenticationService authenticationService, SignInService signInService, AdvertiserAccountService advertiserAccountService)
        {
            _administratorRepository = administratorRepository;
            _authenticationService = authenticationService;
            _signInService = signInService;
            _advertiserAccountService = advertiserAccountService;
        }

        public AuthenticateResponse AuthenticateAdmin(AuthenticateRequest request)
        {
            var errors = request.Validate();
            if (errors.Any())
                throw new ValidationException(errors);

            var user = _administratorRepository.Get(request.Username);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            _authenticationService.AuthenticateAdministrator(request);
            var identity = user as AdministratorIdentity;
            _signInService.SignInAdministratorAsync(identity, true).RunSynchronously();

            return new AuthenticateResponse { RedirectUrl = request.ReturnUrl ?? "/" };
        }

        public AuthenticateResponse AuthenticateAdvertiser(AuthenticateRequest request)
        {
            var errors = request.Validate();
            if (errors.Any())
                throw new ValidationException(errors);

            var user = _administratorRepository.Get(request.Username);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            _authenticationService.AuthenticateAdministrator(request);
            var identity = user as AdministratorIdentity;
            _signInService.SignInAdministratorAsync(identity, true).RunSynchronously();

            return new AuthenticateResponse { RedirectUrl = request.ReturnUrl ?? "/" };
        }

        public NotificationResponse CreateNewAdvertiser(AdvertiserNewAccountRequest request)
        {
            _advertiserAccountService.AddNewAdvertiser(request);
            return new NotificationResponse("Conta criada com sucesso!", NotificationResponse.SUCCESS);
        }
    }
}