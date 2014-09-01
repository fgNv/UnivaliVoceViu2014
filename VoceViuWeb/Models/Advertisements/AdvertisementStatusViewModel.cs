using VoceViuModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuWeb.Models.Advertisements
{
    public class AdvertisementStatusViewModel
    {
        public string Description { get; set; }
        public AdvertisementStatus Value { get; set; }

        public AdvertisementStatusViewModel(AdvertisementStatus value)
        {
            Description = value.GetDescription();
            Value = value;
        }
    }
}