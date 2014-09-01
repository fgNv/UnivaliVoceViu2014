using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Areas.Advertiser.Models
{
    public class SubmitContentRequest
    {
        public int AdvertisementId { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}