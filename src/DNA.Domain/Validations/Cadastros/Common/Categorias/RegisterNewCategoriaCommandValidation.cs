using DNA.Domain.Commands.Cadastros.Common.Categorias;

namespace DNA.Domain.Validations.Cadastros.Common.Categorias
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
