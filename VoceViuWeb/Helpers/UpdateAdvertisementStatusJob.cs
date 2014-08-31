using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Threading;
using SimpleInjector;
using VoceViuPersistence;
using SimpleInjector.Extensions.LifetimeScoping;
using VoceViuModel;
using VoceViuModel.ServiceSolicitations.Services;

namespace VoceViuWeb.Helpers
{
    public static class JobTimer
    {
        private static readonly Timer _timer = new Timer(OnTimerElapsed);
        private static readonly UpdateAdvertisementStatusJob _jobHost = new UpdateAdvertisementStatusJob();

        public static void Start()
        {
            _timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(100000));
        }

        private static void OnTimerElapsed(object sender)
        {
            _jobHost.DoWork();
        }
    }

    public class UpdateAdvertisementStatusJob : IRegisteredObject
    {
        private readonly Container _container;

        public UpdateAdvertisementStatusJob()
        {
            _container = GetContainer();
        }

        public void DoWork()
        {
            using (_container.BeginLifetimeScope())
            {
                var service = _container.GetInstance<AdvertisementService>();
                service.UpdateStatuses();
            }
        }

        public static Container GetContainer()
        {
            var container = new Container();
            var scopedLifestyle = new LifetimeScopeLifestyle();

            container.RegisterPersistenceDependencies(scopedLifestyle);
            container.RegisterModelDependencies(scopedLifestyle);

            return container;
        }

        public void Stop(bool immediate)
        {
            //throw new NotImplementedException();
        }
    }

}