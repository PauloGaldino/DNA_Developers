using DNA.Domain.Commands.Cadastros.Producao.Produto;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
{
    public class RegisterNewCategoriaCommandValidation : CategoriaValidation<CategoriaCommand>
    {
        public RegisterNewCategoriaCommandValidation()
        {
            ValidateDescricao();
        }
    }
}
