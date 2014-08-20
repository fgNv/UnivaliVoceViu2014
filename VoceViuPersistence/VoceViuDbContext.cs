using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Domain;
using VoceViuModel.Users;
using VoceViuPersistence.Mappings.Locations;
using VoceViuPersistence.Mappings.Users;

namespace VoceViuPersistence
{
    public class VoceViuDbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdvertiserMapping());
            modelBuilder.Configurations.Add(new AdministratorMapping());
            modelBuilder.Configurations.Add(new LocationMapping());
            modelBuilder.Configurations.Add(new PointMapping());
        }

        public VoceViuDbContext(string connectionString):base(connectionString) { }

        public VoceViuDbContext()
        {
            var connectionStringName = ConfigurationManager.AppSettings["databaseConnection"];
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            Database.Connection.ConnectionString = conn;
        }
    }
}
