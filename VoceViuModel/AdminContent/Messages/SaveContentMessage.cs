using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.AdminContent.Messages
{
    public class SaveContentMessage
    {
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}
