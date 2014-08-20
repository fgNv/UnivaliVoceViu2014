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
    public class PointMapping : EntityTypeConfiguration<Point>
    {
        public PointMapping()
        {
            ToTable("VV_Locations_Points");
            HasKey(a => a.Id);
        }
    }
}
