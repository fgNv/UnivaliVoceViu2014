using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users;
using VoceViuModel.Users.Messages;

namespace VoceViuTest.Helpers
{
    public class AdvertiserData
    {
        public static Advertiser GetAdvertiser()
        {
            var result = new Advertiser();
            result.Email = "teste@teste.com";
            result.Name = "teste";
            result.UserName = "teste";
            return result;
        }

        public static SaveAdvertiserMessage GetAdvertiserMessage()
        {
            var result = new SaveAdvertiserMessage();
            result.Email = "teste@teste.com";
            result.Name = "teste";
            result.Password = "teste";
            return result;
        }
    }
}
