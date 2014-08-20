using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Locations.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public string Name { get; set; }
        public string PublicType { get; set; }
        public int Spot { get; set; }
        public ICollection<Point> Points { get; set; }

        public Location()
        {
            Points = new Collection<Point>();
        }
    }
}
