using System;
using VoceViuModel.Attachments;

namespace VoceViuModel.ServiceSolicitations.Domain
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Terms { get; set; }
        public string Summary { get; set; }
        public Attachment Content { get; set; }
    }
}
