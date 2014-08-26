﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Messages
{
    public class CreateServiceSolicitationMessage
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LocationId { get; set; }
        public int AdvertiserId { get; set; }
        public int ContractModelId { get; set; }
    }
}


