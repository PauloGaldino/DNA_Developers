using DNA.Domain.Validations.Cadastros.Producao.Produto;

namespace DNA.Domain.Commands.Cadastros.Producao.Produto
{
    public class RegisterNewCategoriaCommand : CategoriaCommand
    {
        public RegisterNewCategoriaCommand(string descricao)
        {
            Descricao = descricao;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCategoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
