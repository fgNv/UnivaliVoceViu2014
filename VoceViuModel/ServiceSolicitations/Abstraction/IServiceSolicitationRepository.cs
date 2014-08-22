using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;

namespace VoceViuModel.ServiceSolicitations.Abstraction
{
    public interface IServiceSolicitationRepository : IRepository
    {
        IEnumerable<ServiceSolicitation> GetAll();
        IEnumerable<ServiceSolicitation> GetByAdvertiser(int id);
        ServiceSolicitation Get(int id);
        void Add(ServiceSolicitation solicitation);
        void Remove(ServiceSolicitation solicitation);
    }
}
