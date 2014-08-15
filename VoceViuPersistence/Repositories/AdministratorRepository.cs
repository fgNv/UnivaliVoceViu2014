using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Users.Abstractions;

namespace VoceViuPersistence.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private readonly VoceViuDbContext _context;

        public AdministratorRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public VoceViuModel.Users.Administrator Get(int id)
        {
            return _context.Administrators.FirstOrDefault(a => a.Id == id);
        }

        public VoceViuModel.Users.Administrator Get(string userName)
        {
            return _context.Administrators.FirstOrDefault(a => a.UserName == userName);
        }

        public void Add(VoceViuModel.Users.Administrator administrator)
        {
            _context.Administrators.Add(administrator);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
