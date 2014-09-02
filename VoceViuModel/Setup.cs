using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.AdminContent.Services;
using VoceViuModel.Locations.Services;
using VoceViuModel.ServiceSolicitations.Services;
using VoceViuModel.Users;
using VoceViuModel.Users.Services;

namespace VoceViuModel
{
    public static class Setup
    {
        public static void RegisterModelDependencies(this Container container, Lifestyle lifestyle)
        {
            container.Register<AdvertiserAccountService, AdvertiserAccountService>(lifestyle);
            container.Register<CryptographyService, CryptographyService>(lifestyle);
            container.Register<AuthenticationService, AuthenticationService>(lifestyle);
            container.Register<LocationService, LocationService>(lifestyle);
            container.Register<ServiceSolicitationService, ServiceSolicitationService>(lifestyle);
            container.Register<ContractModelService,ContractModelService>(lifestyle);
            container.Register<AdvertisementService, AdvertisementService>(lifestyle);
            container.Register<ContentServices, ContentServices>(lifestyle);
        }
    }
}
