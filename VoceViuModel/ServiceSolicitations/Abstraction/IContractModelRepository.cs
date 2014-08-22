using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Domain;

namespace VoceViuModel.ServiceSolicitations.Abstraction
{
    public interface IContractModelRepository
    {
        void Add(ContractModel contractModel);
        void Add(ContractModel object);
    }
}
