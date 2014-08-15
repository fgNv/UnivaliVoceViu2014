using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;

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
    }
}
