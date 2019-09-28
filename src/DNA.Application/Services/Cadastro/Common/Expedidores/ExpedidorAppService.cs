using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNA.Application.EventSourcedNormalizers.Cadastro.Common.Expedidores;
using DNA.Application.Interfaces.Cadastro.Common.Expedidor;
using DNA.Application.ViewModels.Cadastro.Common.Expedidores;
using DNA.Domain.Commands.Cadastros.Common.Expedidores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Interfaces.Cadastros.Common.Expedidores;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace DNA.Application.Services.Cadastro.Common.Expedidores
{
    public class ExpedidorAppService : IExpedidorAppService
    {
        private readonly IMapper _mapper;
        private readonly IExpedidorRepository _expedidorRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ExpedidorAppService(IMapper mapper, IExpedidorRepository expedidorRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _expedidorRepository = expedidorRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ExpedidorViewModel> GetAll()
        {
            return _expedidorRepository.GetAll().ProjectTo<ExpedidorViewModel>(_mapper.ConfigurationProvider);
        }

        public ExpedidorViewModel GetById(Guid id)
        {
            return _mapper.Map<ExpedidorViewModel>(_expedidorRepository.GetById(id));
        }

        public void Register(ExpedidorViewModel expedidorViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewExpedidorCommand>(expedidorViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ExpedidorViewModel expedidorViewModel)
        {
            var updateCommand = _mapper.Map<UpdateExpedidorCommand>(expedidorViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveExpedidorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<ExpedidorHistoryData> GetAllHistory(Guid id)
        {
            return ExpedidorHistory.ToJavaScriptExpedidorHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}