using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoceViuWeb.Models
{
    public class NotificationResponse
    {
        public const string SUCCESS = "success";
        public const string ERROR = "error";
        public const string WARNING = "success";

        public string Title { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public string Type { get; set; }

        public NotificationResponse(string title, IEnumerable<string>messages, string type = null)
        {
            Title = title;
            Messages = messages;
            Type = type;
        }

        public NotificationResponse(string title, string type = null)
        {
            Title = title;
            Type = type;
        }
    }
}