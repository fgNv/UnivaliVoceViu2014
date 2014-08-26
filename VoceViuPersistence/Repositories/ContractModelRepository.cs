using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuPersistence.Repositories
{
    public class ContractModelRepository : IContractModelRepository
    {
        private readonly VoceViuDbContext _context;

        public ContractModelRepository(VoceViuDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ContractModel> GetAll()
        {
            return _context.ContractModels;
        }

        public ContractModel Get(int id)
        {
            return _context.ContractModels.FirstOrDefault(cm => cm.Id == id);
        }

        public void Add(ContractModel contractModel)
        {
            _context.ContractModels.Add(contractModel);
        }

        public void Remove(ContractModel contractModel)
        {
            _context.ContractModels.Remove(contractModel);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
