using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Clientes
{
    public class UpdateClienteCommandValidation : ClienteValidation<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateDataNascimento();
            ValidateEmail();
        }
    }
}