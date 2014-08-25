using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Attachments;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuModel.ServiceSolicitations
{
    public class Advertisement
    {
        public int Id { get; set; }
        public AdvertisementStatus Status {get; set;}
        public ICollection<AdvertisementContent> DeniedContents { get; set; }
        public Attachment Content { get; set; }
        public ServiceSolicitation ServiceSolicitation { get; set; }
    }
}
