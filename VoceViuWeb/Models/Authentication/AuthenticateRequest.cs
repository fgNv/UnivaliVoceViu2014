using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Users.Commands;

namespace VoceViuWeb.Models.Authentication
{
    public class AuthenticateRequest : AuthenticateMessage
    {
        public string ReturnUrl { get; set; }

        public IEnumerable<string> Validate()
        {
            if (String.IsNullOrWhiteSpace(Username))
                yield return "Deve-se fornecer um usuário";

            if (String.IsNullOrWhiteSpace(Password))
                yield return "Deve-se fornecer uma senha";
        }
    }
}