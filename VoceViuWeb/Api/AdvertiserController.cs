using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Services;
using VoceViuWeb.Filters;

namespace VoceViuWeb.Api
{
    [ExceptionHandler]
    public class AdvertiserController : ApiController
    {
        private readonly IAdvertiserRepository _advertiserRepository;
        private readonly AdvertiserService _advertiserService;

        public AdvertiserController(IAdvertiserRepository advertiserRepository, AdvertiserService advertiserService)
        {
            _advertiserRepository = advertiserRepository;
            _advertiserService = advertiserService;

        }

        [HttpGet]
        public IEnumerable<Advertiser> GetAll()
        {
            return _advertiserRepository.GetAll();
        }

        public void Remove(int id)
        {
            _advertiserService.Remove(id);
        }
    }
}