using DNA.Domain.Validations.Cadastros.Common.Fornecedores;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Fornecedores
{
    public class RemoveFornecedorCommand : FornecedorCommand
    {
        public RemoveFornecedorCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFornecedorCommandValidation().Validate(this);
            return ValidationResult.IsValid;

        }
    }
}
