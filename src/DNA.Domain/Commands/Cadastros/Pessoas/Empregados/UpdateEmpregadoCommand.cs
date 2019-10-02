using DNA.Domain.Validations.Cadastros.Pessoas.Empregados;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Empregados
{
    public class UpdateEmpregadoCommand : EmpregadoCommand
    {
        public UpdateEmpregadoCommand(Guid id, string nome, string sobrenome,string cargo, DateTime dataAdmissao, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
            DataNascimento = dataNascimento;
           
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEmpregadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
