using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations;
using System.Threading.Tasks;
using System.Data.Entity;

namespace VoceViuPersistence
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly VoceViuDbContext _context;

        public AdvertisementRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public void Add(Advertisement advertisement)
        {
            _context.Advertisement.Add(advertisement);
        }

        public Advertisement Get(int id)
        {
            return _context.Advertisement
                           .Include(a => a.ServiceSolicitation)
                           .Include(a => a.Content)
                           .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Advertisement> GetAll()
        {
            return _context.Advertisement
                           .Include(a => a.ServiceSolicitation)
                           .Include(a => a.ServiceSolicitation.Advertiser)
                           .Include(a => a.Content)
                           .Include(a => a.ServiceSolicitation.ContractModel)
                           .Include(a => a.ServiceSolicitation.Location);
        }

        public IEnumerable<Advertisement> GetByAdvertiser(int id)
        {
            return _context.Advertisement
                           .Include(a => a.ServiceSolicitation.Advertiser)
                           .Include(a => a.Content)
                           .Where(a => a.ServiceSolicitation.Advertiser.Id == id)
                           .Include(a => a.ServiceSolicitation)
                           .Include(a => a.ServiceSolicitation.ContractModel)
                           .Include(a => a.ServiceSolicitation.Location);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
