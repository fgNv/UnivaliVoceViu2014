using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Messages;

namespace VoceViuModel.Users.Services
{
    public class AdvertiserAccountService
    {
        private readonly IAdvertiserRepository _advertiserRepository;
        private readonly CryptographyService _cryptographyService;

        public AdvertiserAccountService(IAdvertiserRepository advertiserRepository, CryptographyService cryptographyService)
        {
            _advertiserRepository = advertiserRepository;
            _cryptographyService = cryptographyService;
        }

        private void VerifyIfEmailIsTaken(SaveAdvertiserMessage message)
        {
            var isEmailTaken = _advertiserRepository.GetAll()
                                                    .Any(a => a.Email == message.Email);

            if (isEmailTaken)
                throw new Exception("Email já utilizado");
        }

        public Advertiser AddNewAdvertiser(SaveAdvertiserMessage message)
        {
            VerifyIfEmailIsTaken(message);
            var newAdvertiser = new Advertiser();
            newAdvertiser.Name = message.Name;
            newAdvertiser.Password = _cryptographyService.Encrypt(message.Password);
            newAdvertiser.Email = message.Email;

            _advertiserRepository.Add(newAdvertiser);
            _advertiserRepository.SaveChanges();

            return newAdvertiser;
        }

        public void UpdateAdvertiserData(int id, SaveAdvertiserMessage message)
        {
            var advertiser = _advertiserRepository.Get(id);
            advertiser.Email = message.Email;
            advertiser.Name = message.Name;
            advertiser.Password = _cryptographyService.Encrypt(message.Password);

            
        }
    }
}
