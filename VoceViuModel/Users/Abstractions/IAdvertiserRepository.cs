using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;

namespace VoceViuModel.Users.Abstractions
{
    public interface IAdvertiserRepository : IRepository
    {
        Advertiser Get(string userName);
        Advertiser Get(int id);
        IEnumerable<Advertiser> GetAll();
        Task<Advertiser> GetAsync(string userName);
        Task<Advertiser> GetAsync(int id);
        void Add(Advertiser advertiser);
        void Remove(Advertiser advertiser);
    }
}
