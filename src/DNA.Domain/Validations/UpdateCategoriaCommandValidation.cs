using DNA.Domain.Commands;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
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
