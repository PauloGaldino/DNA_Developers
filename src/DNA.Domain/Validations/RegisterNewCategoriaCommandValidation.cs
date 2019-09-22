using DNA.Domain.Commands;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
{
    public class RegisterNewCategoriaCommandValidation : CategoriaValidation<CategoriaCommand>
    {
        public RegisterNewCategoriaCommandValidation()
        {
            ValidateNome();
            ValidateDescricao();
        }
    }
}
