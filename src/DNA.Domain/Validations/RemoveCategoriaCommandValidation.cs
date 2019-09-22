using DNA.Domain.Commands;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
{
    public class RemoveCategoriaCommandValidation :CategoriaValidation<RemoveCategoriaCommand>
    {
        public RemoveCategoriaCommandValidation()
        {
            ValidateId();      
        }
    }
}
