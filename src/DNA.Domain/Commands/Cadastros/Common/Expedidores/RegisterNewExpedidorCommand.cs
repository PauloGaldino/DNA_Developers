using DNA.Domain.Validations.Cadastros.Common.Expedidores;

namespace DNA.Domain.Commands.Cadastros.Common.Expedidores
{
    public class RegisterNewExpedidorCommand : ExpedidorCommand
    {
        public RegisterNewExpedidorCommand(string companhiaNome, string telefone)
        {
            CompanhiaNome = companhiaNome;
            Telefone = telefone;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewExpedidorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
