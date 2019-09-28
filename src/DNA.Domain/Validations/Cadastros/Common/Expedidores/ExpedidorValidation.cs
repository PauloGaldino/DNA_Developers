using DNA.Domain.Commands.Cadastros.Common.Expedidores;
using FluentValidation;
using System;

namespace DNA.Domain.Validations.Cadastros.Common.Expedidores
{
    public abstract class ExpedidorValidation<T> : AbstractValidator<T> where T : ExpedidorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateCompanhiaNome()
        {
            RuleFor(d => d.CompanhiaNome)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do nome")
            .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
        protected void ValidateTelefone()
        {
            RuleFor(d => d.Telefone)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo da Telefone")
            .Length(2, 50).WithMessage("O nome deve ter entre 2 e 50 caracteres.");
        }
    }
}
