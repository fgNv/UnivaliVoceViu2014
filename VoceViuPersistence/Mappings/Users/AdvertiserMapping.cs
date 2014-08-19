using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using VoceViuModel.Users;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoceViuPersistence.Mappings.Users
{
    public class AdvertiserMapping : EntityTypeConfiguration<Advertiser>
    {
        public AdvertiserMapping()
        {
            ToTable("VV_Advertisers");
            HasKey(a => a.Id);

            var emailIndex = new IndexAnnotation(new IndexAttribute("uniqueEmail", 1) { IsUnique = true });
            Property(a => a.Email).HasColumnAnnotation("Index", emailIndex).HasMaxLength(100);

            Ignore(a => a.UserName);
        }
    }
}
