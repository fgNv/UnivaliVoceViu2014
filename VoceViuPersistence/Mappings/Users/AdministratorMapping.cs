using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users;

namespace VoceViuPersistence.Mappings.Users
{
    public class AdministratorMapping :  EntityTypeConfiguration<Administrator>
    {
        public AdministratorMapping()
        {
            ToTable("VV_Administratos");
            HasKey(a => a.Id);
        }
    }
}
