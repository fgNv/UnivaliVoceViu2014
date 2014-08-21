using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitation.Abstraction;
using VoceViuModel.ServiceSolicitation;

namespace VoceViuPersistence.Repositories
{
    public class ServiceSolicitationRepository : IServiceSolicitationRepository
    {
        private readonly VoceViuDbContext _context;

        public ServiceSolicitationRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ServiceSolicitation> GetAll()
        {
            return _context.ServiceSolicitations;
        }

        public VoceViuModel.ServiceSolicitation.ServiceSolicitation Get(int id)
        {
            return _context.ServiceSolicitations.FirstOrDefault(ss => ss.Id == id);
        }

        public void Add(VoceViuModel.ServiceSolicitation.ServiceSolicitation solicitation)
        {
            _context.ServiceSolicitations.Add(solicitation);
        }

        public void Remove(VoceViuModel.ServiceSolicitation.ServiceSolicitation solicitation)
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
    }
}
