using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Users
{
    public class Advertiser : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        string IUser<string>.Id
        {
            get { return this.Id.ToString(); }
        }

        public string UserName
        {
            get
            {
                return this.Email;
            }
            set
            {
                this.Email = value;
            }
        }
    }
}
