using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Attachments;

namespace VoceViuModel.ServiceSolicitations.Domain
{
    public class AdvertisementContent
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime DenialDate { get; set; }
        public Attachment Content { get; set; }
    }
}
