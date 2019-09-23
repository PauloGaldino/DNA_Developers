using System;
using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Commands.Cadastros.Common.Categorias;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using DNA.Domain.Events.Cadastros.Common.Categorias;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Common.Categorias;
using DNA.Domain.Models.Cadastros.Common.Categorias;
using MediatR;

namespace DNA.Domain.CommandHandlers.Cadastros.Comman.Categorias
{
    public class CategoriaCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCategoriaCommand, bool>,
        IRequestHandler<UpdateCategoriaCommand, bool>,
        IRequestHandler<RemoveCategoriaCommand, bool>

    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMediatorHandler Bus;
        public CategoriaCommandHandler(ICategoriaRepository categoriaRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notification)
            :base(uow, bus, notification)
        {
            _categoriaRepository = categoriaRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var categoria = new Categoria(Guid.NewGuid(),message.Nome, message.Descricao);

            if (_categoriaRepository.GetByDescricao(categoria.Descricao) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "A categoria já ja existe. "));
                return Task.FromResult(false);
            }

            _categoriaRepository.Add(categoria);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoriaRegisteredEvent(categoria.Id, categoria.Nome, categoria.Descricao));
            }

            return Task.FromResult(true);        
        }

        public Task<bool> Handle(UpdateCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var categoria = new Categoria(message.Id,message.Nome, message.Descricao);
            var categoriaExiste = _categoriaRepository.GetByDescricao(categoria.Descricao);

            if (categoriaExiste != null && categoriaExiste.Id != categoria.Id)
            {
                if (!categoriaExiste.Equals(categoria))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "A Categria  cliente já foi recebido."));
                    return Task.FromResult(false);
                }
            }

            _categoriaRepository.Update(categoria);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoriaUpdatedEvent(categoria.Id, categoria.Nome, categoria.Descricao));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveCategoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _categoriaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoriaRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _categoriaRepository.Dispose();
        }
    }
}
