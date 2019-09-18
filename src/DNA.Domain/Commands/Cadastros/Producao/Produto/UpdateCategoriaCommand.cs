using DNA.Domain.Validations.Cadastros.Producao.Produto;
using System;

namespace DNA.Domain.Commands.Cadastros.Producao.Produto
{
    public class UpdateCategoriaCommand :CategoriaCommand
    {
        public UpdateCategoriaCommand(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
