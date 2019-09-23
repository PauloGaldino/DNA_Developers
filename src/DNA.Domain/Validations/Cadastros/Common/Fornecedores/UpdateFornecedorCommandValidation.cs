using DNA.Domain.Commands.Cadastros.Common.Fornecedores;

namespace DNA.Domain.Validations.Cadastros.Common.Fornecedores
{
    public class UpdateFornecedorCommandValidation : FornecedorValidation<UpdateFornecedorCommand>
    {
        public UpdateFornecedorCommandValidation()
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
