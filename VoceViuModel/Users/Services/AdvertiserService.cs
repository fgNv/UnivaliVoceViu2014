using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;

namespace VoceViuModel.Users.Services
{
    public class AdvertiserService
    {
        private readonly IAdvertiserRepository _advertiserRepository;

        public AdvertiserService(IAdvertiserRepository advertiserRepository)
        {
            _advertiserRepository = advertiserRepository;

        }


        public void Remove(int id)
        {
            var advertiser = _advertiserRepository.Get(id);
            _advertiserRepository.Remove(advertiser);
            _advertiserRepository.SaveChanges();
        }
    }
}
