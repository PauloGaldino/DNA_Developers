using DNA.Domain.Validations.Cadastros.Producao.Produto;

namespace DNA.Domain.Commands
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
