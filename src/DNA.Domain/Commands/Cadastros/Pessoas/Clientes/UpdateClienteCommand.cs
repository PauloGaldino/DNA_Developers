using DNA.Domain.Validations.Cadastros.Pessoas.Clientes;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Clientes
{
     public class UpdateClienteCommand : ClienteCommand
    {
        public UpdateClienteCommand(Guid id, string nome, string email, DateTime dataNascmento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascmento;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}