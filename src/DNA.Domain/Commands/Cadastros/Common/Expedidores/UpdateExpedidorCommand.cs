using DNA.Domain.Commands.Cadastros.Common.Expedidores;
using DNA.Domain.Validations.Cadastros.Common.Expedidores;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Expedidores
{
     public class UpdateExpedidorCommand : ExpedidorCommand
    {
        public UpdateExpedidorCommand(Guid id,string companhiaNome, string telefone)
        {
            Id = id;
            CompanhiaNome = companhiaNome;
            Telefone = telefone;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateExpedidorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
