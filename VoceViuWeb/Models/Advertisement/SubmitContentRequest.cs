using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Models.Advertisement
{
    public class SubmitContentRequest
    {
        public HttpPostedFileBase File { get; set; }
    }
}