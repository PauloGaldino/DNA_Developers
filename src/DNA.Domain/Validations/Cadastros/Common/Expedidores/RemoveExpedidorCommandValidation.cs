using DNA.Domain.Commands.Cadastros.Common.Expedidores;

namespace DNA.Domain.Validations.Cadastros.Common.Expedidores
{
    public class RemoveExpedidorCommandValidation : ExpedidorValidation<ExpedidorCommand>
    {
        public RemoveExpedidorCommandValidation()
        {
            ValidateId();
        }
    }
}
