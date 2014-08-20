using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Domain;

namespace VoceViuPersistence.Mappings.Locations
{
    public class LocationMapping : EntityTypeConfiguration<Location>
    {
        public LocationMapping()
        {
            ToTable("VV_Locations");
            HasKey(a => a.Id);

            HasMany(l => l.Points).WithRequired();

            var nameIndex = new IndexAnnotation(new IndexAttribute("uniqueName", 1) { IsUnique = true });
            Property(a => a.Name).HasColumnAnnotation("Index", nameIndex).HasMaxLength(100);
        }
    }
}
