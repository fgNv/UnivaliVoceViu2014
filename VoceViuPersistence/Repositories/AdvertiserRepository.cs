using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;
using System.Data.Entity;

namespace VoceViuPersistence.Repositories
{
    public class AdvertiserRepository : IAdvertiserRepository
    {
        private readonly VoceViuDbContext _context;

        public AdvertiserRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public VoceViuModel.Users.Advertiser Get(string userName)
        {
            return _context.Advertisers.FirstOrDefault(a => a.Email == userName);
        }

        public VoceViuModel.Users.Advertiser Get(int id)
        {
            return _context.Advertisers.FirstOrDefault(a => a.Id == id);
        }

        public void Add(VoceViuModel.Users.Advertiser advertiser)
        {
            _context.Advertisers.Add(advertiser);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task<VoceViuModel.Users.Advertiser> GetAsync(string userName)
        {
            return _context.Advertisers.FirstOrDefaultAsync(a => a.UserName == userName);
        }

        public Task<VoceViuModel.Users.Advertiser> GetAsync(int id)
        {
            return _context.Advertisers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Remove(VoceViuModel.Users.Advertiser advertiser)
        {
            _context.Advertisers.Remove(advertiser);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoceViuModel.Users.Advertiser> GetAll()
        {
            return _context.Advertisers;
        }
    }
}
