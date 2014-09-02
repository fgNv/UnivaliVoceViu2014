using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.AdminContent;

namespace VoceViuWeb.Models
{
    public class ContentViewModel
    {
        public string FileName { get; set; }
        public int FileId { get; set; }
        public int ContentId { get; set; }

        public ContentViewModel(Content content)
        {
            FileName = content.Attachment.Name;
            FileId = content.Attachment.Id;
            ContentId = content.Id;
        }
    }
}