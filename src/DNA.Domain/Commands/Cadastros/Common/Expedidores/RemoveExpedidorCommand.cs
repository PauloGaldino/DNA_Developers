using DNA.Domain.Validations.Cadastros.Common.Expedidores;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Expedidores
{
    public class RemoveExpedidorCommand : ExpedidorCommand
    {
        public RemoveExpedidorCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveExpedidorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
