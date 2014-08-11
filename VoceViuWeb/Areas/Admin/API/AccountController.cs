using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Commands;
using VoceViuModel.Users.Services;
using VoceViuWeb.Exceptions;
using VoceViuWeb.Models.Authentication;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Admin.API
{
    public class AccountController : ApiController
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly SignInService _signInService;

        public AccountController(IAdministratorRepository administratorRepository, AuthenticationService authenticationService, SignInService signInService)
        {
            _administratorRepository = administratorRepository;
            _authenticationService = authenticationService;
            _signInService = signInService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
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
    }
}