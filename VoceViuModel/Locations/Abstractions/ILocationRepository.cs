using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;
using VoceViuModel.Locations.Domain;

namespace VoceViuModel.Locations.Abstractions
{
    public interface ILocationRepository : IRepository
    {
        void Add(Location location);
        Location Get(int id);
        IEnumerable<Location> GetAll();
        void Remove(Location location);
    }
}
