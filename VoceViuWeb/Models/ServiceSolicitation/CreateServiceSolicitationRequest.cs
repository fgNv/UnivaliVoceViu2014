using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuWeb.Helpers;

namespace VoceViuWeb.Models.ServiceSolicitations
{
    public class CreateServiceSolicitationRequest
    {
        public int LocationId { get; set; }
        public string StartMonth { get; set; }
        public int MonthQuantity { get; set; }
        public int ContractModelId { get; set; }

        public CreateServiceSolicitationMessage GetMessage()
        {
            var splittedStartMonth = StartMonth.Split('/');
            var startMonth = Int32.Parse(splittedStartMonth[0]);
            var startYear = Int32.Parse(splittedStartMonth[1]);
            var startDate = new DateTime(startYear, startMonth, 1);

            var message = new CreateServiceSolicitationMessage();
            var user = HttpContext.Current.User;

            message.LocationId = LocationId;
            message.AdvertiserId = user.GetUserId();
            message.StartDate = startDate;
            message.EndDate = startDate.AddMonths(MonthQuantity);
            message.ContractModelId = ContractModelId;

            return message;
        }
    }
}