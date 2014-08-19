using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuPersistence;
using VoceViuModel;

namespace VoceViuTest
{
    public class Setup
    {
        public static Container GetContainer()
        {
            var container = new Container();
            var scopedLifestyle = new LifetimeScopeLifestyle();

            container.RegisterPersistenceDependencies(scopedLifestyle);
            container.RegisterModelDependencies(scopedLifestyle);

            return container;
        }
    }
}
