using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuWeb.Models.ServiceSolicitations;

namespace VoceViuWeb.Models.Advertisements
{
    public class AdvertisementViewModel
    {
        public int Id { get; set; }
        public AdvertisementStatus Status { get; set; }
        public ServiceSolicitationViewModel ServiceSolicitation { get; set; }

        public AdvertisementViewModel(Advertisement model)
        {
            Id = model.Id;
            Status = model.Status;
            ServiceSolicitation = new ServiceSolicitationViewModel(model.ServiceSolicitation);
        }
    }
}