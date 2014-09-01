using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Models.ContractModels
{
    public class CreateContractModelRequest
    {
        public string Name { get; set; }
        public string Terms { get; set; }
        public string Summary { get; set; }
        public HttpPostedFileBase Attachment { get; set; }
    }
}