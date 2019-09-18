using DNA.Domain.Commands.Cadastros.Producao.Produto;

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
