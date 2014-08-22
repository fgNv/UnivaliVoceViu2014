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

        public void Add(CreateServiceSolicitationRequest request)
        {
            var message = new CreateServiceSolicitationMessage();
            var user = HttpContext.Current.User;

            message.LocationId = request.LocationId;
            message.AdvertiserId = user.GetUserId();
            message.StartDate = request.StartDate;
            message.EndDate = request.EndDate;

            _serviceSolicitationService.Create(message);
        }
    }
}