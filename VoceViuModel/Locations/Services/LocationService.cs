using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.Locations.Domain;
using VoceViuModel.Locations.Messages;

namespace VoceViuModel.Locations.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Add(SaveLocationMessage message)
        {
            var location = new Location();
            location.IP = message.IP;
            location.Name = message.Name;
            location.PublicType = message.PublicType;
            location.Spot = message.Spot;
            foreach (var pointVm in message.Points)
                location.Points.Add(new Point { Name = pointVm.Name });

            _locationRepository.Add(location);
            _locationRepository.SaveChanges();
        }

        private void UpdatePoints(SaveLocationMessage message, Location location)
        {
            var requestPointsIds = message.Points.Where(p => p.Id.HasValue).Select(p => p.Id.Value);
            var excludedPointsIds = location.Points.Select(p => p.Id).Where(i => !requestPointsIds.Contains(i));

            foreach (var excludedId in excludedPointsIds)
            {
                var point = location.Points.FirstOrDefault(p => p.Id == excludedId);
                location.Points.Remove(point);
            }

            foreach (var pointVm in message.Points.Where(vm => !vm.Id.HasValue))
                location.Points.Add(new Point { Name = pointVm.Name });

            foreach (var pointVm in message.Points.Where(vm => vm.Id.HasValue))
            {
                var point = location.Points.FirstOrDefault(p => p.Id == pointVm.Id.Value);
                point.Name = pointVm.Name;
            }
        }

        public void Update(SaveLocationMessage message, int id)
        {
            var location = _locationRepository.Get(id);
            location.IP = message.IP;
            location.Name = message.Name;
            location.PublicType = message.PublicType;
            location.Spot = message.Spot;

            UpdatePoints(message, location);
            _locationRepository.SaveChanges();
        }

        public void Remove(int id)
        {

        }
    }
}
