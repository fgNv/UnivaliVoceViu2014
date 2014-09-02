using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.Users;
using VoceViuModel.Users.Abstractions;

namespace VoceViuWeb.Api
{
    public class AdvertiserController : ApiController
    {
        private readonly IAdvertiserRepository _advertiserRepository;

        public AdvertiserController(IAdvertiserRepository advertiserRepository)
        {
            _advertiserRepository = advertiserRepository;

        }

        [HttpGet]
        public IEnumerable<Advertiser> GetAll()
        {
            return _advertiserRepository.GetAll();
        }



    }

     
}