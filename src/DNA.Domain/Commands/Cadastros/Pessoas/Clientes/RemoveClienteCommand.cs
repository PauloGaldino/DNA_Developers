using DNA.Domain.Validations.Cadastros.Pessoas.Clientes;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Clientes
{
    public class RemoveClienteCommand : ClienteCommand
    {
        public RemoveClienteCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}