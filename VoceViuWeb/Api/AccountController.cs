using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Commands;
using VoceViuModel.Users.Services;
using VoceViuWeb.Exceptions;
using VoceViuWeb.Filters;
using VoceViuWeb.Models;
using VoceViuWeb.Models.Account;
using VoceViuWeb.Models.Authentication;
using VoceViuWeb.Services;

namespace VoceViuWeb.Areas.Admin.API
{
    [ExceptionHandler]
    public class AccountController : ApiController
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly AuthenticationService _authenticationService;
        private readonly SignInService _signInService;
        private readonly AdvertiserAccountService _advertiserAccountService;
        private readonly IAdvertiserRepository _advertiserRepository;
        private readonly AdministratorAccountService _administratorAccountService;

        public AccountController(IAdministratorRepository administratorRepository, AuthenticationService authenticationService, SignInService signInService, AdvertiserAccountService advertiserAccountService, IAdvertiserRepository advertiserRepository, AdministratorAccountService administratorAccountService)
        {
            _administratorRepository = administratorRepository;
            _authenticationService = authenticationService;
            _signInService = signInService;
            _advertiserAccountService = advertiserAccountService;
            _advertiserRepository = advertiserRepository;
            _administratorAccountService = administratorAccountService;
        }

        public void AddAdd()
        {
            _administratorAccountService.Create("admin", "admin");
        }

        public async Task<AuthenticateResponse> AuthenticateAdministrator(AuthenticateRequest request)
        {
            var errors = request.Validate();
            if (errors.Any())
                throw new ValidationException(errors);

            var user = _administratorRepository.Get(request.Username);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            _authenticationService.AuthenticateAdministrator(request);
            await _signInService.SignInAdministratorAsync(user, true);

            return new AuthenticateResponse { ReturnUrl = request.ReturnUrl ?? "/Admin/Home/Index" };
        }

        public async Task<AuthenticateResponse> AuthenticateAdvertiser(AuthenticateRequest request)
        {
            var errors = request.Validate();
            if (errors.Any())
                throw new ValidationException(errors);

            var user = _advertiserRepository.Get(request.Username);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            _authenticationService.AuthenticateAdvertiser(request);
            await _signInService.SignInAdvertiserAsync(user, true);

            return new AuthenticateResponse { ReturnUrl = request.ReturnUrl ?? "/Advertiser/Home/Index" };
        }

        public async Task<ReturnUrlResponse> CreateNewAdvertiser(AdvertiserNewAccountRequest request)
        {
            _advertiserAccountService.AddNewAdvertiser(request);
            var user = _advertiserRepository.Get(request.Email);
            await _signInService.SignInAdvertiserAsync(user, true);
            return new ReturnUrlResponse("/Advertiser/Home/Index");
        }
    }
}