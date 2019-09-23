using DNA.Domain.Commands.Cadastros.Common.Fornecedores;

namespace DNA.Domain.Validations.Cadastros.Common.Fornecedores
{
    public class RegisterNewFornecedorCommandValidation : FornecedorValidation<RegisterNewFornecedorCommand>
    {
        public RegisterNewFornecedorCommandValidation()
        {
            ValidateNomeCompanhia();
            ValidateNomeContato();
            ValidateTituloContato();
            ValidateTelefone();
            ValidateEmail();
            ValidateCidade();
            ValidateEstado();
            ValidatePais();
        }
    }
}
