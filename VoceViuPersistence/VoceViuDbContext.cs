using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users;

namespace VoceViuPersistence
{
    public class VoceViuDbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }

        public VoceViuDbContext(string connectionString):base(connectionString) { }

        public VoceViuDbContext() { }
    }
}
