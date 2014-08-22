using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Domain
{
    public class AdvertisementContent
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime DenialDate { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
