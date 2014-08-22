using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Models.ServiceSolicitation
{
    public class CreateServiceSolicitationRequest
    {
        public int LocationId { get; set; }
        public string StartMonth { get; set; }
        public int MonthQuantity { get; set; }
        public int ContractModelId { get; set; }
    }
}