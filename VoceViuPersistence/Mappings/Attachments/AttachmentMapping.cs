using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Attachments;

namespace VoceViuPersistence.Mappings.Attachments
{
    public class AttachmentMapping : EntityTypeConfiguration<Attachment>
    {
        public AttachmentMapping()
        {
            ToTable("VV_Attachments");
            HasKey(a => a.Id);
        }
    }
}
