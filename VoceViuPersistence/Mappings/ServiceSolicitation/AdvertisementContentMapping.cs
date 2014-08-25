using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Domain;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuPersistence.Mappings
{
    public class AdvertisementContentMapping : EntityTypeConfiguration<AdvertisementContent>
    {
        public AdvertisementContentMapping()
        {
            ToTable("VV_Advertisements_Contents");
            HasKey(a => a.Id);

            HasOptional(ac => ac.Content);
        }
    }
}
