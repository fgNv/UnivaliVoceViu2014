using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Domain;

namespace VoceViuModel.Locations.Messages
{
    public class SaveLocationMessage
    {
        public IEnumerable<PointViewModel> Points { get; set; }
        public string IP { get; set; }
        public string Name { get; set; }
        public int Spot { get; set; }
        public string PublicType { get; set; }
        public double MonthlyValue { get; set; }

        public class PointViewModel
        {
            public int? Id { get; set; }
            public string Name { get; set; }
        }
    }
}
