using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.ServiceSolicitations.Services;
using VoceViuWeb.Models.Advertisements;
using VoceViuWeb.Models.ServiceSolicitations;

namespace VoceViuWeb.Api
{
    public class AdvertisementController : ApiController
    {
        private readonly AdvertisementService _advertisementService;
        private readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementController(AdvertisementService advertisementService, IAdvertisementRepository advertisementRepository)
        {
            _advertisementService = advertisementService;
            _advertisementRepository = advertisementRepository;
        }

        public void DenyContent(int id, DenyAdvertisementContentMessage message)
        {
            _advertisementService.DenyContent(id, message);
        }

        public void ApproveContent(int id)
        {
            _advertisementService.ApproveContent(id);
        }

        public IEnumerable<AdvertisementViewModel> GetAll()
        {
            var result = _advertisementRepository.GetAll()
                                                 .Select(m => new AdvertisementViewModel(m));
            return result;
        }

        public IEnumerable<AdvertisementStatusViewModel> GetAdvertisementStatus()
        {
            var result = Enum.GetValues(typeof(AdvertisementStatus))
                             .Cast<AdvertisementStatus>()
                             .Select(v => new AdvertisementStatusViewModel(v));

            return result;
        }
    }
}