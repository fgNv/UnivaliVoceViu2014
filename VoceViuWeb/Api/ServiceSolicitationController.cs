using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.ServiceSolicitation;
using VoceViuModel.ServiceSolicitation.Abstraction;
using VoceViuModel.ServiceSolicitation.Messages;
using VoceViuModel.ServiceSolicitation.Services;

namespace VoceViuWeb.Api
{
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
            return _serviceSolicitationRepository.GetAll();
        }

        public void Add(CreateServiceSolicitationMessage message)
        {
            _serviceSolicitationService.Create(message);
        }
    }
}