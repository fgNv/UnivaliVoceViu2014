using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoceViuModel.Users.Abstractions
{
    public interface IAdvertiserRepository
    {
        Advertiser Get(string userName);
        Advertiser Get(int id);
        void Add(Advertiser advertiser);

    }
}
