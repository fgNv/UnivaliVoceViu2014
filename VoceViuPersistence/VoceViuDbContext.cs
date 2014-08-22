using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Domain;
using VoceViuModel.ServiceSolicitations;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.Users;
using VoceViuPersistence.Mappings;
using VoceViuPersistence.Mappings.Locations;
using VoceViuPersistence.Mappings.ServiceSolicitations;
using VoceViuPersistence.Mappings.Users;

namespace VoceViuPersistence
{
    public class VoceViuDbContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Advertiser> Advertisers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AdvertisementContent> AdvertisementContents { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<ContractModel> ContractModels { get; set; }
        public DbSet<ServiceSolicitation> ServiceSolicitations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdvertiserMapping());
            modelBuilder.Configurations.Add(new AdministratorMapping());
            modelBuilder.Configurations.Add(new LocationMapping());
            modelBuilder.Configurations.Add(new PointMapping());

            modelBuilder.Configurations.Add(new AdvertisementContentMapping());
            modelBuilder.Configurations.Add(new AdvertisementMapping());
            modelBuilder.Configurations.Add(new ContractModelMapping());
            modelBuilder.Configurations.Add(new ServiceSolicitationMapping());
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
