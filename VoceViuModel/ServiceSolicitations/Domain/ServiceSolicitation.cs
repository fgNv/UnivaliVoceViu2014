using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = VoceViuModel.Locations.Domain.Location;
using Advertiser = VoceViuModel.Users.Advertiser;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuModel.ServiceSolicitations
{
    public class ServiceSolicitation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyValue { get; set; }
        public ContractModel ContractModel { get; set; }
        public Location Location { get; set; }
        public Advertisement Advertisement { get; set; }
        public Advertiser Advertiser { get; set; }

    }
}
