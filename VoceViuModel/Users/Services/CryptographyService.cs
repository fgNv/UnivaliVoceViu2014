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
            var salt = "$2a$06$NRL3FWgZ/Ojnas0GC242zO";
            return Crypter.Blowfish.Crypt(input, salt);
        }
    }
}
