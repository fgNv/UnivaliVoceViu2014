using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Users.Messages;

namespace VoceViuWeb.Models.Account
{
    public class AdvertiserNewAccountRequest : SaveAdvertiserMessage
    {
        public IEnumerable<string> Validate()
        {
            if (String.IsNullOrWhiteSpace(this.Email))
                yield return "Deve-se fornecer um email";

            if (String.IsNullOrWhiteSpace(this.Name))
                yield return "Deve-se fornecer um nome";

            if (String.IsNullOrWhiteSpace(this.Password))
                yield return "Deve-se fornecer uma senha";
        }
    }
}