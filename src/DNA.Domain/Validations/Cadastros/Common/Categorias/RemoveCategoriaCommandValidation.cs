using DNA.Domain.Commands.Cadastros.Common.Categorias;

namespace DNA.Domain.Validations.Cadastros.Common.Categorias
{
    public class RemoveCategoriaCommandValidation :CategoriaValidation<RemoveCategoriaCommand>
    {
        public RemoveCategoriaCommandValidation()
        {
            ValidateId();      
        }
    }
}
