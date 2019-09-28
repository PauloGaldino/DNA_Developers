using DNA.Domain.Commands.Cadastros.Common.Expedidores;

namespace DNA.Domain.Validations.Cadastros.Common.Expedidores
{
    public class UpdateExpedidorCommandValidation : ExpedidorValidation<ExpedidorCommand>
    {
        public UpdateExpedidorCommandValidation()
        {
            ValidateId();
            ValidateCompanhiaNome();
            ValidateTelefone();
        }
    }
}
