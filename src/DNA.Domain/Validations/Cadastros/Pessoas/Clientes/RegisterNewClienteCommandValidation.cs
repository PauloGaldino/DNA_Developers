using DNA.Domain.Commands.Cadastros.Pessoas.Clientes;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Clientes
{
    public class RegisterNewClienteCommandValidation : ClienteValidation<RegisterNewClienteCommand>
    {
        public RegisterNewClienteCommandValidation()
        {
            ValidateNome();
            ValidateDataNascimento();
            ValidateEmail();
        }
    }
}