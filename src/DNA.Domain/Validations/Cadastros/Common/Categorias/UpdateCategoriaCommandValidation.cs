using DNA.Domain.Commands.Cadastros.Common.Categorias;

namespace DNA.Domain.Validations.Cadastros.Common.Categorias
{
    public class UpdateCategoriaCommandValidation : CategoriaValidation<UpdateCategoriaCommand>
    {
        public UpdateCategoriaCommandValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateDescricao();
        }
    }
}
