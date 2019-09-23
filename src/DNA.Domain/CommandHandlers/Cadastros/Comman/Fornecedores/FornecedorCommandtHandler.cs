using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using DNA.Domain.Events.Cadastros.Common.Fornecedores;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Common.Fornecedores;
using DNA.Domain.Models.Cadastros.Common.Fornecedores;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DNA.Domain.CommandHandlers.Cadastros.Comman.Fornecedores
{
    public class FornecedorCommandtHandler : CommandHandler,
        IRequestHandler<RegisterNewFornecedorCommand, bool>,
        IRequestHandler<UpdateFornecedorCommand, bool>,
        IRequestHandler<RemoveFornecedorCommand, bool>

    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMediatorHandler Bus;
        public FornecedorCommandtHandler(IFornecedorRepository fornecedorRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notification)
            : base(uow, bus, notification)
        {
            _fornecedorRepository = fornecedorRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewFornecedorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var fornecedor = new Fornecedor(Guid.NewGuid(), message.NomeCompanhia, message.NomeContato,message.TituloContato,
                message.Telefone, message.EnderecoEmail, message.Endereco, message.Cidade, message.Estado, message.Pais);

            if (_fornecedorRepository.GetByNomeCompanhia(fornecedor.NomeCompanhia) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "A categoria já ja existe. "));
                return Task.FromResult(false);
            }

            _fornecedorRepository.Add(fornecedor);

            if (Commit())
            {
                Bus.RaiseEvent(new FornecedorRegisteredEvent(fornecedor.Id, fornecedor.NomeCompanhia, fornecedor.NomeContato,fornecedor.TituloContato, fornecedor.Telefone,
                    fornecedor.EnderecoEmail,fornecedor.Endereco,fornecedor.Cidade,fornecedor.Estado, fornecedor.Pais));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateFornecedorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var fornecedor = new Fornecedor(message.Id, message.NomeCompanhia, message.NomeContato, message.TituloContato,
                message.Telefone, message.EnderecoEmail, message.Endereco, message.Cidade, message.Estado, message.Pais);

            var fornecedorExiste = _fornecedorRepository.GetByNomeCompanhia(fornecedor.NomeCompanhia);

            if (fornecedorExiste != null && fornecedorExiste.Id != fornecedor.Id)
            {
                if (!fornecedorExiste.Equals(fornecedor))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "A Categria já foi recebido."));
                    return Task.FromResult(false);
                }
            }

            _fornecedorRepository.Update(fornecedor);

            if (Commit())
            {
                Bus.RaiseEvent(new FornecedorUpdatedEvent(fornecedor.Id, fornecedor.NomeCompanhia, fornecedor.NomeContato,fornecedor.TituloContato,
                    fornecedor.Telefone, fornecedor.EnderecoEmail, fornecedor.Endereco, fornecedor.Cidade, fornecedor.Estado, fornecedor.Pais));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveFornecedorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _fornecedorRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new FornecedorRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _fornecedorRepository.Dispose();
        }
    }
}
