﻿using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Events.Cadastros.Pessoas.Empregados;
using MediatR;

namespace DNA.Domain.EventHandlers.Cadastros.Pessoas.Empregados
{
    public class EmpregadoEventHandler :
        INotificationHandler<EmpregadoRegisteredEvent>,
        INotificationHandler<EmpregadoRemovedEvent>,
        INotificationHandler<EmpregadoUpdatedEvent>
    {
        public Task Handle(EmpregadoRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Enviar algum email de notificação
            return Task.CompletedTask;
        }

        public Task Handle(EmpregadoRemovedEvent notification, CancellationToken cancellationToken)
        {
            // Enviar algum email de saudação
            return Task.CompletedTask;
        }

        public Task Handle(EmpregadoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Enviar algum email em breve
            return Task.CompletedTask;
        }
    }
}
