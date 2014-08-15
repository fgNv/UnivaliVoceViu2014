using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoceViuModel.Users;

namespace VoceViuWeb.Models.Authentication
{
    public class AdvertiserIdentity : Advertiser, IUser
    {

        public new string Id
        {
            get { return base.Id.ToString(); }
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