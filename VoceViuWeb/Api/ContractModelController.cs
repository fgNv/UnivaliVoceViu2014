using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using VoceViuModel.ServiceSolicitations.Abstraction;
using VoceViuModel.ServiceSolicitations.Domain;
using VoceViuModel.ServiceSolicitations.Messages;
using VoceViuModel.ServiceSolicitations.Services;
using VoceViuWeb.Filters;

namespace VoceViuWeb.Api
{
    [ExceptionHandlerAttribute]
    public class ContractModelController : ApiController
    {
        private readonly ContractModelService _contractModelService;
        private readonly IContractModelRepository _contractModelRepository;

        public ContractModelController(ContractModelService contractModelService, IContractModelRepository contractModelRepository)
        {
            _contractModelService = contractModelService;
            _contractModelRepository = contractModelRepository;
        }

        public ContractModel Get(int id)
        {
            return _contractModelRepository.Get(id);
        }

        public IEnumerable<ContractModel> GetAll()
        {
            return _contractModelRepository.GetAll();
        }

        public void Add(SaveContractModelMessage message)
        {
            _contractModelService.Add(message);
        }

        public void Remove(int id)
        {
            _contractModelService.Remove(id);
        }

        public void Update(int id, SaveContractModelMessage message)
        {
            _contractModelService.Update(id, message);
        }
    }
}