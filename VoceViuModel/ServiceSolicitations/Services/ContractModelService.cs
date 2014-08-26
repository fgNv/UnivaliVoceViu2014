using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.ServiceSolicitations.Messages;

namespace VoceViuModel.ServiceSolicitations.Services
{
    public class ContractModelService
    {
        private readonly IContractModelRepository _contractModelRepository;

        public ContractModelService(IContractModelRepository contractModelRepository)
        {
            _contractModelRepository = contractModelRepository;
        }

        public void Add(SaveContractModelMessage message)
        {
            var contractModel = new ContractModel();
            contractModel.Name = message.Name;
            contractModel.Summary = message.Summary;
            contractModel.Terms = message.Terms;

            _contractModelRepository.Add(contractModel);
            _contractModelRepository.SaveChanges();
        }

        public void Update(int id, SaveContractModelMessage message)
        {
            var contractModel = _contractModelRepository.Get(id);
            contractModel.Name = message.Name;
            contractModel.Summary = message.Summary;
            contractModel.Terms = message.Terms;

            _contractModelRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var contractModel = _contractModelRepository.Get(id);
            _contractModelRepository.Remove(contractModel);
            _contractModelRepository.SaveChanges();
        }
    }
}
