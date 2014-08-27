using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Locations.Domain;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.Users;

namespace VoceViuWeb.Models.ServiceSolicitations
{
    public class ServiceSolicitationViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyValue { get; set; }
        public ContractModel ContractModel { get; set; }
        public Location Location { get; set; }
        public Advertiser Advertiser { get; set; }

        public ServiceSolicitationViewModel(ServiceSolicitation model)
        {
            Id = model.Id;
            StartDate = model.StartDate;
            EndDate = model.EndDate;
            MonthlyValue = model.MonthlyValue;
            ContractModel = model.ContractModel;
            Location = model.Location;
            Advertiser = model.Advertiser;
        }
    }
}