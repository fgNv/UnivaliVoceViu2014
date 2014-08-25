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
using VoceViuWeb.Models.ServiceSolicitation;

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

        public IEnumerable<ServiceSolicitation> GetAll()
        {
            var user = HttpContext.Current.User;

            if (user.IsAdmin())
                return _serviceSolicitationRepository.GetAll();

            return _serviceSolicitationRepository.GetByAdvertiser(user.GetUserId());
        }

        [AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN)]
        public void ApproveServiceSolicitation(int id)
        {
            _serviceSolicitationService.Approve(id);
        }

        public void Add(CreateServiceSolicitationRequest request)
        {
            var splittedStartMonth = request.StartMonth.Split('/');
            var startMonth = Int32.Parse(splittedStartMonth[0]);
            var startYear = Int32.Parse(splittedStartMonth[1]);
            var startDate = new DateTime(startYear, startMonth, 1);

            var message = new CreateServiceSolicitationMessage();
            var user = HttpContext.Current.User;

            message.LocationId = request.LocationId;
            message.AdvertiserId = user.GetUserId();
            message.StartDate = startDate;
            message.EndDate = startDate.AddMonths(request.MonthQuantity);
            message.ContractModelId = request.ContractModelId;

            _serviceSolicitationService.Create(message);
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