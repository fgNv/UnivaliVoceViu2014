using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using VoceViuModel.Users;

namespace VoceViuPersistence.Mappings.Users
{
    public class AdvertiserMapping : EntityTypeConfiguration<Advertiser>
    {
        public AdvertiserMapping()
        {
            ToTable("VV_Advertisers");
            HasKey(a => a.Id);
        }
    }
}
