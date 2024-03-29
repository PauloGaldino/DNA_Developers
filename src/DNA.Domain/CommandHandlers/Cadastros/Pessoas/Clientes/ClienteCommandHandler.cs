﻿using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using DNA.Domain.Events.Cadastros.Pessoas.Clientes;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Clientes;
using DNA.Domain.Models.Cadastros.Pessoas;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace DNA.Domain.CommandHandlers.Cadastros.Pessoas.Clientes
{
    public class ClienteCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewClienteCommand, bool>,
        IRequestHandler<UpdateClienteCommand, bool>,
        IRequestHandler<RemoveClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler Bus;

        public ClienteCommandHandler(IClienteRepository clienteRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _clienteRepository = clienteRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var cliente = new Cliente(Guid.NewGuid(), message.Nome, message.Email, message.DataNascimento);

            if (_clienteRepository.GetByEmail(cliente.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do cliente já foi recebido. "));
                return Task.FromResult(false);
            }

            _clienteRepository.Add(cliente);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRegisteredEvent(cliente.Id, cliente.Nome, cliente.Email, cliente.DataNascimento ));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.DataNascimento);
            var clienteExiste = _clienteRepository.GetByEmail(cliente.Email);

            if (clienteExiste != null && clienteExiste.Id != cliente.Id)
            {
                if (!clienteExiste.Equals(cliente))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O email do cliente já foi recebido."));
                    return Task.FromResult(false);
                }
            }

            _clienteRepository.Update(cliente);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteUpdatedEvent(cliente.Id, cliente.Nome, cliente.Email, cliente.DataNascimento));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _clienteRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ClienteRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}