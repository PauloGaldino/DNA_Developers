using DNA.Domain.Commands.Cadastros.Producao.Produto;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
{
    public class UpdateCategoriaCommandValidation : CategoriaValidation<UpdateCategoriaCommand>
    {
        public UpdateCategoriaCommandValidation()
        {
            ValidateId();
            ValidateDescricao();
        }
    }
}
