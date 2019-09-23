using DNA.Domain.Validations.Cadastros.Common.Categorias;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Categorias
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
