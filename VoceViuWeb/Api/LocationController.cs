using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.Locations.Domain;
using VoceViuModel.Locations.Messages;
using VoceViuModel.Locations.Services;
using VoceViuWeb.Filters;
using VoceViuWeb.Services;

namespace VoceViuWeb.Api
{
    //[AuthorizeByClaimAttribute(SignInService.PROFILE_TYPE_ADMIN, SignInService.PROFILE_TYPE_ADVERTISER)]
    public class LocationController : ApiController
    {
        private readonly ILocationRepository _locationRepository;
        private readonly LocationService _locationService;

        public LocationController(ILocationRepository locationRepository, LocationService locationService)
        {
            _locationRepository = locationRepository;
            _locationService = locationService;
        }

        [HttpGet]
        public IEnumerable<Location> GetAll()
        {
            return _locationRepository.GetAll();
        }

        [HttpGet]
        public Location Get(int id)
        {
            return _locationRepository.Get(id);
        }

        public void Add(SaveLocationMessage message)
        {
            _locationService.Add(message);
        }

        public void Update(int id, SaveLocationMessage message)
        {
            _locationService.Update(message, id);
        }

        public void Remove(int id)
        {
            _locationService.Remove(id);
        }
    }
}