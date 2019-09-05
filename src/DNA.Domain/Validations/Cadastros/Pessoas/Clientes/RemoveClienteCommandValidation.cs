using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Clientes
{
    public class RemoveClienteCommandValidation : ClienteValidation<RemoveClienteCommand>
    {
        public RemoveClienteCommandValidation()
        {
            ValidateId();
        }
    }
}