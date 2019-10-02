using DNA.Domain.Commands.Cadastros.Common.Expedidores;

namespace DNA.Domain.Validations.Cadastros.Common.Expedidores
{
    public class RegisterNewExpedidorCommandValidation : ExpedidorValidation<ExpedidorCommand>
    {
        public RegisterNewExpedidorCommandValidation()
        {
            ValidateCompanhiaNome();
            ValidateTelefone();
        }
    }
}
