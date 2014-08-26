using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Users;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;

namespace VoceViuWeb.Models.Authentication.Implementations
{
    public class AdministratorStore : IUserStore<Administrator>
    {
        private readonly IAdministratorRepository _administratorRepository;

        public AdministratorStore(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        public Task CreateAsync(Administrator user)
        {
            _administratorRepository.Add(user) ;
            return _administratorRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(Administrator user)
        {
            _administratorRepository.Remove(user);
            return _administratorRepository.SaveChangesAsync();
        }

        public Task<Administrator> FindByIdAsync(string userId)
        {
            return _administratorRepository.GetAsync(Int32.Parse(userId));
        }

        public Task<Administrator> FindByNameAsync(string username)
        {
            return _administratorRepository.GetAsync(username);
        }

        public Task UpdateAsync(Administrator user)
        {
            var updatedUser = _administratorRepository.Get(user.Id);
            updatedUser.Name = user.Name;
            updatedUser.UserName = user.UserName;
            return _administratorRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _administratorRepository.Dispose();
        }
    }
}