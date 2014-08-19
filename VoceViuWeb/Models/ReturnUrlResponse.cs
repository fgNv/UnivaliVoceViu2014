using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Models
{
    public class ReturnUrlResponse
    {
        public string ReturnUrl { get; private set; }

        public ReturnUrlResponse(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }
    }
}