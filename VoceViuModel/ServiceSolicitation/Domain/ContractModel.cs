using System;

namespace VoceViuModel.ServiceSolicitation.Domain
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Terms { get; set; }
        public string Summary { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }

    }
}
