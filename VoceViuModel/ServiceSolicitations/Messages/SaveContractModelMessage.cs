using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.ServiceSolicitations.Messages
{
    public class SaveContractModelMessage
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Terms { get; set; }
    }
}
