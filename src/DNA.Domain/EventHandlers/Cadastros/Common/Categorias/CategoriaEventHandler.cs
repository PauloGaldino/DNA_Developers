﻿using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Events.Cadastros.Common.Categorias;
using MediatR;

namespace DNA.Domain.EventHandlers.Cadastros.Common.Categorias
{
    public class CategoriaEventHandler :
        INotificationHandler<CategoriaRegisteredEvent>,
        INotificationHandler<CategoriaRemovedEvent>,
        INotificationHandler<CategoriaUpdatedEvent>
    {

        public Task Handle(CategoriaRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Enviar algum email de notificação

            return Task.CompletedTask;
        }

        public Task Handle(CategoriaRemovedEvent message, CancellationToken cancellationToken)
        {
            // Envie um e-mail de saudações
            return Task.CompletedTask;
        }

        public Task Handle(CategoriaUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Envie alguns e-mails em breve

            return Task.CompletedTask;
        }
    }
}
