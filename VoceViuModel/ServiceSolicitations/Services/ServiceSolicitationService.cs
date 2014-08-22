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

        public ServiceSolicitationService(IServiceSolicitationRepository serviceSolicitationRepository, ILocationRepository locationRepository, IAdvertiserRepository advertiserRepository)
        {
            _serviceSolicitationRepository = serviceSolicitationRepository;
            _locationRepository = locationRepository;
            _advertiserRepository = advertiserRepository;
        }

        public void Create(CreateServiceSolicitationMessage message)
        {
            var serviceSolicitation = new ServiceSolicitation();
            serviceSolicitation.Location = _locationRepository.Get(message.LocationId);
            serviceSolicitation.Advertiser = _advertiserRepository.Get(message.AdvertiserId);
            serviceSolicitation.EndDate = message.EndDate;
            serviceSolicitation.MonthlyValue = message.MonthlyValue;
            serviceSolicitation.StartDate = message.StartDate;

            _serviceSolicitationRepository.Add(serviceSolicitation);
            _serviceSolicitationRepository.SaveChanges();
        }
    }
}
