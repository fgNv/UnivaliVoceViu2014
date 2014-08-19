using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Services;

namespace VoceViuTest
{
    [TestClass]
    public class CryptographyServiceTests
    {
        [TestMethod]
        public void SameInputEncryptedTwiceComparison()
        {
            var service = new CryptographyService();
            var input = "test";

            var encryptOne = service.Encrypt(input);
            var encryptTwo = service.Encrypt(input);

            Assert.AreEqual(encryptOne, encryptTwo);
        }
    }
}
