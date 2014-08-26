using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Extensions.LifetimeScoping;
using SimpleInjector;
using SimpleInjector.Extensions;
using VoceViuTest.Helpers;
using VoceViuModel.Users.Abstractions;
using VoceViuModel.Users.Services;

namespace VoceViuTest
{
    [TestClass]
    public class AdvertiserAccountServiceTests
    {
        [TestMethod]
        public void CreateAdvertiser()
        {
            var container = Setup.GetContainer();

            using (container.BeginLifetimeScope())
            {
                var message = AdvertiserData.GetAdvertiserMessage();
                var advertiserAccountService = container.GetInstance<AdvertiserAccountService>();
                advertiserAccountService.AddNewAdvertiser(message);
            }

            using (container.BeginLifetimeScope())
            {
                var advertiserRepository = container.GetInstance<IAdvertiserRepository>();
                var retrievedAdvertiser = advertiserRepository.GetAll().FirstOrDefault();

                Assert.IsNotNull(retrievedAdvertiser);
            }
        }
    }
}
