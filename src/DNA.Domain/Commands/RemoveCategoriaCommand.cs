using DNA.Domain.Validations.Cadastros.Producao.Produto;
using System;

namespace DNA.Domain.Commands
{
    public class RemoveCategoriaCommand : CategoriaCommand
    {
        public RemoveCategoriaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;

        }
      
    }
}
