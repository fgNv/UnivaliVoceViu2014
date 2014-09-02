using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Areas.Admin.Models
{
    public class AddContentRequest
    {
        public HttpPostedFileBase File { get; set; }
    }
}