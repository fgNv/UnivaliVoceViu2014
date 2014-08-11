using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Users.Commands
{
    public class AuthenticateMessage
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticateMessage(string userName, string password)
        {
            Username = userName;
            Password = password;
        }

        public AuthenticateMessage()
        {

        }
    }
}
