using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Events.Cadastros.Common.Expedidores;
using MediatR;

namespace DNA.Domain.EventHandlers.Cadastros.Common.Expedidores
{
    public class ExpedidorEventHandler :
        INotificationHandler<ExpedidorRegisteredEvent>,
        INotificationHandler<ExpedidorUpdatedEvent>,
        INotificationHandler<ExpedidorRemovedEvent>
    {
        public Task Handle(ExpedidorRegisteredEvent message, CancellationToken cancellationToken)
        {
            //Enviar algun e-mail de notificação
            return Task.CompletedTask;
        }

        public Task Handle(ExpedidorUpdatedEvent message, CancellationToken cancellationToken)
        {
            //Envia e-mail de saudação
            return Task.CompletedTask;
        }

        public Task Handle(ExpedidorRemovedEvent message, CancellationToken cancellationToken)
        {
            //Envia algum e-mail em breve
            return Task.CompletedTask;
        }
    }
}
