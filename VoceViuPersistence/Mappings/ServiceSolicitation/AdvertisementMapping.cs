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

namespace VoceViuPersistence.Mappings
{
    public class AdvertisementMapping : EntityTypeConfiguration<Advertisement>
    {
        public AdvertisementMapping()
        {
            ToTable("VV_Advertisements");
            HasKey(a => a.Id);

            HasMany(a => a.DeniedContent).WithRequired();


        }
    }
}
