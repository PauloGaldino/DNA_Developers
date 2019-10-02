using System;
using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Commands.Cadastros.Common.Expedidores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using DNA.Domain.Events.Cadastros.Common.Expedidores;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Common.Expedidores;
using DNA.Domain.Models.Cadastros.Common.Expedidores;
using MediatR;

namespace DNA.Domain.CommandHandlers.Cadastros.Comman.Expedidores
{
    public class ExpedidorCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewExpedidorCommand, bool>,
        IRequestHandler<RemoveExpedidorCommand, bool>,
        IRequestHandler<UpdateExpedidorCommand, bool>
    {
        private readonly IExpedidorRepository _expedidorRepository;
        private readonly IMediatorHandler Bus;

        public ExpedidorCommandHandler(IExpedidorRepository expedidorRepository, 
                                        IUnitOfWork uow, 
                                        IMediatorHandler bus, 
                                        INotificationHandler<DomainNotification> notification) : base(uow, bus, notification)
        {
            _expedidorRepository = expedidorRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewExpedidorCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var expedidor = new Expedidor(Guid.NewGuid(), message.CompanhiaNome, message.Telefone);

            if (_expedidorRepository.GetByNomeCompanhia(expedidor.CompanhiaNome) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O nome deste expedidro já exixte"));
                return Task.FromResult(false);
            }
            _expedidorRepository.Add(expedidor);

            if (Commit())
            {
                Bus.RaiseEvent(new ExpedidorRegisteredEvent(expedidor.Id, expedidor.CompanhiaNome, expedidor.Telefone));

            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveExpedidorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _expedidorRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ExpedidorRemovedEvent(message.Id));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateExpedidorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var expedidor = new Expedidor(Guid.NewGuid(), message.CompanhiaNome, message.Telefone);
            var expedidorExiste = _expedidorRepository.GetByNomeCompanhia(expedidor.CompanhiaNome);

            if(expedidorExiste != null && expedidorExiste.Id != expedidor.Id) 
            {
                if (!expedidorExiste.Equals(expedidor))
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O expedidoro já foi recebido"));
                return Task.FromResult(false);
            }

            _expedidorRepository.Update(expedidor);
            if (Commit())
            {
                Bus.RaiseEvent(new ExpedidorUpdatedEvent(expedidor.Id, expedidor.CompanhiaNome, expedidor.Telefone));
            }
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _expedidorRepository.Dispose();
        }
    }
}
