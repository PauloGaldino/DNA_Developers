using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using System;

namespace DNA.Domain.Validations.Cadastros.Common.Fornecedores
{
    public class RemoveFornecedorCommandValidation : FornecedorValidation<RemoveFornecedorCommand>
    {
        public RemoveFornecedorCommandValidation()
        {
            ValidateId();
        }
    }
}