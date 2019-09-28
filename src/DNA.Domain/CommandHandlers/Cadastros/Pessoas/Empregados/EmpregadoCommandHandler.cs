using System.Threading;
using System.Threading.Tasks;
using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;
using DNA.Domain.Core.Bus;
using DNA.Domain.Core.Notifications;
using DNA.Domain.Events.Cadastros.Pessoas.Empregados;
using DNA.Domain.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Empregados;
using DNA.Domain.Models.Cadastros.Pessoas;
using MediatR;

namespace DNA.Domain.CommandHandlers.Cadastros.Pessoas.Empregados
{
    public class EmpregadoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewEmpregadoCommand, bool>,
        IRequestHandler<RemoveEmpregadoCommand, bool>,
        IRequestHandler<UpdateEmpregadoCommand, bool>
    {
        private readonly IEmpregadoRepository _empregadoRepository;
        private readonly IMediatorHandler Bus;
        public EmpregadoCommandHandler(IEmpregadoRepository empregadoRepository, 
                                        IUnitOfWork uow, 
                                        IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications): base(uow,bus,notifications)
        {
            _empregadoRepository = empregadoRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewEmpregadoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var empregado = new Empregado(message.Id, message.Nome, message.Sobrenome, message.Cargo, message.DataAdmissao, message.DataNascimento);
            
            if(_empregadoRepository.GetByNome(empregado.Nome) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O nome do Empregado já foi recebido"));
            }

            _empregadoRepository.Add(empregado);

            if(Commit())
            {
                Bus.RaiseEvent(new EmpregadoRegisteredEvent(message.Id, message.Nome, message.Sobrenome, message.Cargo, message.DataAdmissao, message.DataNascimento));
            }


            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateEmpregadoCommand message ,CancellationToken cancellationToken)
        {
           if(!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var empregado = new Empregado(message.Id, message.Nome, message.Sobrenome, message.Cargo, message.DataAdmissao, message.DataNascimento);
            var empregadoExiste = _empregadoRepository.GetByNome(empregado.Nome);

            if(empregadoExiste !=null && empregadoExiste.Id == empregado.Id)
            {
                if (!empregadoExiste.Equals(empregado))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "o nome do empregado já foi recebido"));
                    return Task.FromResult(false);
                }
            }

            _empregadoRepository.Update(empregado);

            if(Commit())
            {
                Bus.RaiseEvent(new EmpregadoRegisteredEvent(message.Id, message.Nome, message.Sobrenome, message.Cargo, message.DataAdmissao, message.DataNascimento));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveEmpregadoCommand message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
