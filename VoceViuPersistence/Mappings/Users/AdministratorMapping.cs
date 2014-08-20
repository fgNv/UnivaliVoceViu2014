using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users;

namespace VoceViuPersistence.Mappings.Users
{
    public class AdministratorMapping : EntityTypeConfiguration<Administrator>
    {
        public AdministratorMapping()
        {
            ToTable("VV_Administrators");
            HasKey(a => a.Id);

            var usernameIndex = new IndexAnnotation(new IndexAttribute("uniqueUsername", 1) { IsUnique = true });
            Property(a => a.UserName).HasColumnAnnotation("Index", usernameIndex).HasMaxLength(100);
        }
    }
}
