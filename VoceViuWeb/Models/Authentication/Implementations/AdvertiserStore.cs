using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Users;
using VoceViuModel.Users.Abstractions;

namespace VoceViuWeb.Models.Authentication.Implementations
{
    public class AdvertiserStore : IUserStore<Advertiser>
    {
        private readonly IAdvertiserRepository _advertiserRepository;

        public AdvertiserStore(IAdvertiserRepository advertiserRepository)
        {
            _advertiserRepository = advertiserRepository;
        }

        public Task CreateAsync(Advertiser user)
        {
            _advertiserRepository.Add(user);
            return _advertiserRepository.SaveChangesAsync();
        }

        public Task DeleteAsync(Advertiser user)
        {
            _advertiserRepository.Remove(user);
            return _advertiserRepository.SaveChangesAsync();
        }

        public Task<Advertiser> FindByIdAsync(string userId)
        {
            return _advertiserRepository.GetAsync(Int32.Parse(userId));
        }

        public Task<Advertiser> FindByNameAsync(string userName)
        {
            return _advertiserRepository.GetAsync(userName);
        }

        public Task UpdateAsync(Advertiser user)
        {
            var updatedUser = _advertiserRepository.Get(user.Id);
            updatedUser.Email = user.Email;
            updatedUser.Name = user.Name;
            updatedUser.UserName = user.UserName;
            return _advertiserRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _advertiserRepository.Dispose();
        }
    }
}