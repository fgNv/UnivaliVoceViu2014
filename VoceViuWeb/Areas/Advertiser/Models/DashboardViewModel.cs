using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Areas.Advertiser
{
    public class DashboardViewModel
    {
        public int PendingContentAdvertisementCount { get; set; }
        public int PendingPaymentAdvertisementCount { get; set; }
    }
}