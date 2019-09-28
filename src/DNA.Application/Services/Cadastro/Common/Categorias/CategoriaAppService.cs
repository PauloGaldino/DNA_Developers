using AutoMapper;
using AutoMapper.QueryableExtensions;
using DNA.Application.EventSourcedNormalizers.Cadastro.Common.Categorias;
using DNA.Application.Interfaces.Cadastro.Common.Categorias;
using DNA.Application.ViewModels.Cadastro.Common.Categorias;
using DNA.Domain.Commands.Cadastros.Common.Categorias;
using DNA.Domain.Core.Bus;
using DNA.Domain.Interfaces.Cadastros.Common.Categorias;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using System;
using System.Collections.Generic;

namespace DNA.Application.Services.Cadastro.Common.Categorias
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CategoriaAppService(IMapper mapper, ICategoriaRepository categoriaRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            return _categoriaRepository.GetAll().ProjectTo<CategoriaViewModel>(_mapper.ConfigurationProvider);
        }

        public CategoriaViewModel GetById(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(_categoriaRepository.GetById(id));
        }
      
        public void Register(CategoriaViewModel categoriaViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCategoriaCommand>(categoriaViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CategoriaViewModel categoriaViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCategoriaCommand>(categoriaViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCategoriaCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<CategoriaHistoryData> GetAllHistory(Guid id)
        {
            return CategoriaHistory.ToJavaScriptCategoriaHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
