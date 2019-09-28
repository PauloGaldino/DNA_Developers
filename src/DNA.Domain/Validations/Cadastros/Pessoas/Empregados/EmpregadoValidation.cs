using DNA.Domain.Commands.Cadastros.Pessoas.Empregados;
using FluentValidation;
using System;

namespace DNA.Domain.Validations.Cadastros.Pessoas.Empregados
{
    public class EmpregadoValidation<T> : AbstractValidator<T> where T : EmpregadoCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Verifique se você digitou o Nome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }
        protected void ValidateSobrenome()
        {
            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Verifique se você digitou o Sobrenome.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }
        protected void ValidateCargo()
        {
            RuleFor(c => c.Cargo)
                .NotEmpty().WithMessage("Verifique se você digitou o Cargo.")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 0 caracteres.");
        }

        protected void ValidateDataAncimento()
        {
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("O cliente deve ter 16 anos ou mais");
        }
        protected void ValidateDataAdmissao()
        {
            RuleFor(c => c.DataAdmissao)
                .NotEmpty();
               
        }


        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool HaveMinimumAge(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.AddYears(-16);
        }
    }
}
