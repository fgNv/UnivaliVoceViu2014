using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.Users.Abstractions;

namespace VoceViuModel.ServiceSolicitations.Services
{
    public class ServiceSolicitationService
    {
        private readonly IServiceSolicitationRepository _serviceSolicitationRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAdvertiserRepository _advertiserRepository;
        private readonly IContractModelRepository _contractModelRepository;
        private readonly IAdvertisementRepository _advertisementRepository;

        public ServiceSolicitationService(IServiceSolicitationRepository serviceSolicitationRepository, 
                                          ILocationRepository locationRepository,
                                          IAdvertiserRepository advertiserRepository,
                                          IContractModelRepository contractModelRepository,
                                          IAdvertisementRepository advertisementRepository)
        {
            _serviceSolicitationRepository = serviceSolicitationRepository;
            _locationRepository = locationRepository;
            _advertiserRepository = advertiserRepository;
            _contractModelRepository = contractModelRepository;
            _advertisementRepository = advertisementRepository;
        }

        public void Create(CreateServiceSolicitationMessage message)
        {
            var serviceSolicitation = new ServiceSolicitation();
            serviceSolicitation.Location = _locationRepository.Get(message.LocationId);
            serviceSolicitation.Advertiser = _advertiserRepository.Get(message.AdvertiserId);
            serviceSolicitation.EndDate = message.EndDate;
            serviceSolicitation.ContractModel = _contractModelRepository.Get(message.ContractModelId);
            serviceSolicitation.MonthlyValue = serviceSolicitation.Location.MonthlyValue;
            serviceSolicitation.StartDate = message.StartDate;

            _serviceSolicitationRepository.Add(serviceSolicitation);
            _serviceSolicitationRepository.SaveChanges();
        }

        public void Approve(int serviceSolicitationId)
        {
            var serviceSolicitation = _serviceSolicitationRepository.Get(serviceSolicitationId);

            if (serviceSolicitation.Advertisement != null)
                throw new Exception("Essa solicitação de serviço já foi aprovada");

            var advertisement = new Advertisement();
            serviceSolicitation.Advertisement = advertisement;
            advertisement.Status = Domain.AdvertisementStatus.PendingContentDispatch;
            _advertisementRepository.Add(advertisement);
            _serviceSolicitationRepository.SaveChanges();
        }
    }
}
