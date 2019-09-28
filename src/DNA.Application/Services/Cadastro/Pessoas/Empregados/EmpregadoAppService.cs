using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Empregados;
using DNA.Application.Interfaces.Cadastro.Pessoas.Empregados;
using DNA.Application.ViewModels.Cadastro.Pessoas.Empregados;
using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;
using DNA.Domain.Core.Bus;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Empregados;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace DNA.Application.Services.Cadastro.Pessoas.Empregados
{
    public class EmpregadoAppService : IEmpregadoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEmpregadoRepository _empregadoRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public EmpregadoAppService(IMapper mapper, IEmpregadoRepository empregadoRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _empregadoRepository = empregadoRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<EmpregadoViewModel> GetAll()
        {
            return _empregadoRepository.GetAll().ProjectTo<EmpregadoViewModel>(_mapper.ConfigurationProvider);
        }

        public EmpregadoViewModel GetById(Guid id)
        {
            return _mapper.Map<EmpregadoViewModel>(_empregadoRepository.GetById(id));
        }

        public void Register(EmpregadoViewModel empregadoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewEmpregadoCommand>(empregadoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(EmpregadoViewModel empregadoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateEmpregadoCommand>(empregadoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveEmpregadoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<EmpregadoHistoryData> GetAllHistory(Guid id)
        {
            return EmpregadoHistory.ToJavaScriptEmpregadoHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
  