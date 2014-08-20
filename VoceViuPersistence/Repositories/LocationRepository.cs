using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.Locations.Domain;

namespace VoceViuPersistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly VoceViuDbContext _context;

        public LocationRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public void Add(Location location)
        {
            _context.Locations.Add(location);
        }

        public Location Get(int id)
        {
            return _context.Locations.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Location> GetAll()
        {
            return _context.Locations;
        }

        public void Remove(VoceViuModel.Locations.Domain.Location location)
        {
             _context.Locations.Remove(location);
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
