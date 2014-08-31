using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.ServiceSolicitations.Services;
using VoceViuWeb.Filters;
using VoceViuWeb.Services;
using VoceViuWeb.Helpers;
using VoceViuWeb.Models.ServiceSolicitations;

namespace VoceViuWeb.Api
{
    [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN, SignInService.PROFILE_TYPE_ADMIN)]
    public class ServiceSolicitationController : ApiController
    {
        private readonly IServiceSolicitationRepository _serviceSolicitationRepository;
        private readonly ServiceSolicitationService _serviceSolicitationService;

        public ServiceSolicitationController(IServiceSolicitationRepository serviceSolicitationRepository, ServiceSolicitationService serviceSolicitationService)
        {
            _serviceSolicitationRepository = serviceSolicitationRepository;
            _serviceSolicitationService = serviceSolicitationService;
        }

        public IEnumerable<ServiceSolicitationViewModel> GetAll()
        {
            var user = HttpContext.Current.User;

            if (user.IsAdmin())
                return _serviceSolicitationRepository.GetAll()
                                                     .Select(m => new ServiceSolicitationViewModel(m));

            return _serviceSolicitationRepository.GetByAdvertiser(user.GetUserId())
                                                 .Select(m => new ServiceSolicitationViewModel(m));
        }

        public IEnumerable<ServiceSolicitationViewModel> GetPendingApproval()
        {
            var user = HttpContext.Current.User;

            if (user.IsAdmin())
                return _serviceSolicitationRepository.GetAll()
                                                     .Where(m => m.Advertisement == null)
                                                     .Select(m => new ServiceSolicitationViewModel(m));

            return _serviceSolicitationRepository.GetByAdvertiser(user.GetUserId())
                                                 .Where(m => m.Advertisement == null)
                                                 .Select(m => new ServiceSolicitationViewModel(m));
        }

        [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN)]
        public void Approve(int id)
        {
            _serviceSolicitationService.Approve(id);
        }

        [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN)]
        public void Deny(int id)
        {
            _serviceSolicitationService.Deny(id);
        }

        public void Add(CreateServiceSolicitationRequest request)
        {
            _serviceSolicitationService.Create(request.GetMessage());
        }

        [HttpGet]
        public IEnumerable<MonthOption> GetAvailableMonths()
        {
            var now = DateTime.Now;
            for (var i = 1; i < 6; i++)
                yield return new MonthOption { Text = String.Format("{0:MM/yyyy}", now.AddMonths(i)) };
        }

        public class MonthOption
        {
            public string Text { get; set; }
        }
    }
}