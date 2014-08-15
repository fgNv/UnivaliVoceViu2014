using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;
using VoceViuPersistence.Repositories;

namespace VoceViuPersistence
{
    public class Setup
    {
        public void RegisterDependencies(Container container, Lifestyle lifestyle)
        {
            container.Register<VoceViuDbContext>(() => new VoceViuDbContext()  ,lifestyle);
            container.Register<IAdvertiserRepository, AdvertiserRepository>(lifestyle);
            container.Register<IAdministratorRepository, AdministratorRepository>(lifestyle);
        }
    }
}
