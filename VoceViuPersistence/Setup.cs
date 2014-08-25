using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Locations.Abstractions;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.Users.Abstractions;
using VoceViuPersistence.Repositories;

namespace VoceViuPersistence
{
    public static class Setup
    {
        public static void RegisterPersistenceDependencies(this Container container, Lifestyle lifestyle)
        {
            var connectionStringName = ConfigurationManager.AppSettings["databaseConnection"];
            var conn = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            container.Register<VoceViuDbContext>(() => new VoceViuDbContext(conn), lifestyle);
            container.Register<IAdvertiserRepository, AdvertiserRepository>(lifestyle);
            container.Register<IAdministratorRepository, AdministratorRepository>(lifestyle);
            container.Register<ILocationRepository, LocationRepository>(lifestyle);
            container.Register<IServiceSolicitationRepository, ServiceSolicitationRepository>(lifestyle);
            container.Register<IContractModelRepository, ContractModelRepository>(lifestyle);
            container.Register<IAdvertisementRepository, AdvertisementRepository>();
        }
    }
}
