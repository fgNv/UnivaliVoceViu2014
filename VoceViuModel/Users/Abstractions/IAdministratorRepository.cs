using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;

namespace VoceViuModel.Users.Abstractions
{
    public interface IAdministratorRepository : IRepository
    {
        Administrator Get(int id);
        Administrator Get(string userName);
        void Add(Administrator administrator);
        void Remove(Administrator administrator);
        Task<Administrator> GetAsync(int id);
        Task<Administrator> GetAsync(string username);
    }
}
