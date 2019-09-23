using DNA.Domain.Events.Cadastros.Common.Fornecedores;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DNA.Domain.EventHandlers.Cadatros.Common.Fornecedores
{
    public class FornecedorEventHandler :
        INotificationHandler<FornecedorRegisteredEvent>,
        INotificationHandler<FornecedorRemovedEvent>,
        INotificationHandler<FornecedorUpdatedEvent>
    {

        public Task Handle(FornecedorRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Enviar algum email de notificação

            return Task.CompletedTask;
        }

        public Task Handle(FornecedorRemovedEvent message, CancellationToken cancellationToken)
        {
            // Envie um e-mail de saudações
            return Task.CompletedTask;
        }

        public Task Handle(FornecedorUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Envie alguns e-mails em breve

            return Task.CompletedTask;
        }
    }
}
