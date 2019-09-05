using DNA.Domain.Validations.Cadastros.Pessoas.Clientes;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Clientes
{
    public class RegisterNewClienteCommand : ClienteCommand
    {
        public RegisterNewClienteCommand(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

