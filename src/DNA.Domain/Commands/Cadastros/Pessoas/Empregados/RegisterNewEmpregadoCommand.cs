using DNA.Domain.Validations.Cadastros.Pessoas.Empregados;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Empregados
{
    public class RegisterNewEmpregadoCommand : EmpregadoCommand
    {
        public RegisterNewEmpregadoCommand(string nome, string sobrenome,string cargo, DateTime dataAdmissao, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
            DataNascimento = dataNascimento; 
           
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewEmpregadoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
