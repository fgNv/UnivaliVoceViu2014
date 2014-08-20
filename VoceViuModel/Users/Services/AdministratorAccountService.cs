using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;

namespace VoceViuModel.Users.Services
{
    public class AdministratorAccountService
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly CryptographyService _cryptographyService;

        public AdministratorAccountService(IAdministratorRepository administratorRepository, CryptographyService cryptographyService)
        {
            _administratorRepository = administratorRepository;
            _cryptographyService = cryptographyService;
        }

        public void Create(string username, string password)
        {
            var account = new Administrator();
            account.Name = username;
            account.UserName = username;
            account.Password = _cryptographyService.Encrypt(password);
            _administratorRepository.Add(account);
            _administratorRepository.SaveChanges();
        }
    }
}
