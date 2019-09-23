using DNA.Domain.Validations.Cadastros.Common.Categorias;

namespace DNA.Domain.Commands.Cadastros.Common.Categorias
{
    public class RegisterNewCategoriaCommand : CategoriaCommand
    {
        public RegisterNewCategoriaCommand(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
