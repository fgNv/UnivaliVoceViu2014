using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users;
using VoceViuPersistence.Mappings.Users;

namespace VoceViuPersistence
{
    public class VoceViuDbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdvertiserMapping());
            modelBuilder.Configurations.Add(new AdministratorMapping());
            //base.OnModelCreating(modelBuilder);
        }

        public VoceViuDbContext(string connectionString):base(connectionString) { }

        public VoceViuDbContext()
        {
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Database.Connection.ConnectionString = conn;
        }
    }
}
