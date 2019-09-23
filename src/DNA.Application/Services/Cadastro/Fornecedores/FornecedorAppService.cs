using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNA.Application.EventSourcedNormalizers.Cadasrtro.Fornecedores;
using DNA.Application.EventSourcedNormalizers.Cadastro.Fornecedores;
using DNA.Application.Interfaces.Cadastro.Fornecedores;
using DNA.Application.ViewModels.Cadastro.Fornecedores;
using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Interfaces.Cadastros.Common.Fornecedores;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace DNA.Application.Services.Cadastro.Fornecedores
{
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public FornecedorAppService(IMapper mapper, IFornecedorRepository fornecedorRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<FornecedorViewModel> GetAll()
        {
            return _fornecedorRepository.GetAll().ProjectTo<FornecedorViewModel>(_mapper.ConfigurationProvider);
        }

        public FornecedorViewModel GetById(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(_fornecedorRepository.GetById(id));
        }

        public void Register(FornecedorViewModel fornecedorViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewFornecedorCommand>(fornecedorViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(FornecedorViewModel fornecedorViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFornecedorCommand>(fornecedorViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveFornecedorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<FornecedorHistoryData> GetAllHistory(Guid id)
        {
            return FornecedorHistory.ToJavaScriptFornecedorHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
