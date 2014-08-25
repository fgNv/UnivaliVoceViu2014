using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Messages
{
    public class SetAdvertisementContentMessage
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
