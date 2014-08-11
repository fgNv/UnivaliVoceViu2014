using CryptSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Users.Services
{
    public class CryptographyService
    {
        public string Encrypt(string input)
        {
            return Crypter.Blowfish.Crypt(input);
        }
    }
}
