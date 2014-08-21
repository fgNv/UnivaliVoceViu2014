using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitation.Messages
{
    public class CreateServiceSolicitationMessage
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyValue { get; set; }
        public int LocationId { get; set; }
        public int AdvertiserId { get; set; }
    }
}


