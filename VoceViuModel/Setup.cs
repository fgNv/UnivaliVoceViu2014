using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
