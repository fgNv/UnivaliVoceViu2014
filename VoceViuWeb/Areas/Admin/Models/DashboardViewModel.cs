using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int PendingServiceSolicitationsCount { get; set; }
        public int PendingContentApprovalAdvertisementsCount { get; set; }
        public int PendingPaymentAdvertisementsCount { get; set; }
    }
}