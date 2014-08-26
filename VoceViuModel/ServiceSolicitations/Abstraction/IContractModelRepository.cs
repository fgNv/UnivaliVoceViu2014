using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.Abstractions;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuModel.ServiceSolicitations.Abstraction
{
    public interface IContractModelRepository : IRepository
    {
        IEnumerable<ContractModel> GetAll();
        ContractModel Get(int id);
        void Add(ContractModel contractModel);
        void Remove(ContractModel contractModel);
    }
}
