using DNA.Domain.Validations.Cadastros.Producao.Produto;
using System;

namespace DNA.Domain.Commands
{
    public class UpdateCategoriaCommand :CategoriaCommand
    {
        public UpdateCategoriaCommand(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
