using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Services;

namespace VoceViuWeb.Api
{
    public class ExhibitionController : ApiController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly AdvertisementService _advertisementService;

        public ExhibitionController(ILocationRepository locationRepository, AdvertisementService advertisementService)
        {
            _locationRepository = locationRepository;
            _advertisementService = advertisementService;
        }

        public ExhibitionConfiguration GetConfiguration(int locationId)
        {
            var location = _locationRepository.Get(locationId);
            var advertisements = _advertisementService.GetExhibitionAdvertisementsByLocation(location);
            return new ExhibitionConfiguration(advertisements);
        }
    }

    public class ExhibitionConfiguration
    {
        public IEnumerable<int> AdvertimentsIds { get; set; }

        public ExhibitionConfiguration(IEnumerable<Advertisement> advertisements)
        {
            AdvertimentsIds = advertisements.Select(a => a.Id);
        }
    }
}