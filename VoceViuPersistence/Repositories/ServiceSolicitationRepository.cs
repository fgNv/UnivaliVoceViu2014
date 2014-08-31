using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations;
using System.Data.Entity;

namespace VoceViuPersistence.Repositories
{
    public class ServiceSolicitationRepository : IServiceSolicitationRepository
    {
        private readonly VoceViuDbContext _context;

        public ServiceSolicitationRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        private IEnumerable<ServiceSolicitation> GetAllWithAllIncludes()
        {
            return _context.ServiceSolicitations
                           .Include(ss => ss.Advertiser)
                           .Include(ss => ss.ContractModel)
                           .Include(ss => ss.Location)
                           .Include(ss => ss.Advertisement);
        }


        public IEnumerable<ServiceSolicitation> GetAll()
        {
            return GetAllWithAllIncludes();
        }

        public ServiceSolicitation Get(int id)
        {
            return _context.ServiceSolicitations
                           .Include(ss => ss.Advertisement)
                           .FirstOrDefault(ss => ss.Id == id);
        }

        public void Add(ServiceSolicitation solicitation)
        {
            _context.ServiceSolicitations.Add(solicitation);
        }

        public void Remove(ServiceSolicitation solicitation)
        {
            _context.ServiceSolicitations.Remove(solicitation);
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

        public IEnumerable<ServiceSolicitation> GetByAdvertiser(int id)
        {
            return GetAllWithAllIncludes()
                           .Where(ss => ss.Advertiser.Id == id);
        }
    }
}
