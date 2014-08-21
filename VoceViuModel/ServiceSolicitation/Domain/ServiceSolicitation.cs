using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = VoceViuModel.Locations.Domain.Location;
using Advertiser = VoceViuModel.Users.Advertiser;

namespace VoceViuModel.ServiceSolicitation
{
    public class ServiceSolicitation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyValue { get; set; }
        public Location Location { get; set; }
        public Advertisement Advertisement { get; set; }
        public Advertiser Advertiser { get; set; }

    }
}
