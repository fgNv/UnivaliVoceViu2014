using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;

namespace VoceViuModel.ServiceSolicitations.Abstraction
{
    public interface IAdvertisementRepository : IRepository
    {
        void Add(Advertisement advertisement);
        Advertisement Get(int id);
        IEnumerable<Advertisement> GetAll();
        IEnumerable<Advertisement> GetByAdvertiser(int id);
    }
}
