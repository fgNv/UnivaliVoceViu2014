using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations;

namespace VoceViuPersistence.Mappings.ServiceSolicitations
{
    public class ServiceSolicitationMapping : EntityTypeConfiguration<ServiceSolicitation>
    {
        public ServiceSolicitationMapping()
        {
            ToTable("VV_ServiceSolicitations");
            HasKey(a => a.Id);

            HasOptional(s => s.Advertisement).WithRequired();

            HasRequired(s => s.Advertiser);
        }

    }
}
