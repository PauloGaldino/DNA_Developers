using DNA.Domain.Commands.Cadastros.Common.Categorias;
using FluentValidation;
using System;

namespace DNA.Domain.Validations.Cadastros.Common.Categorias
{
    public abstract class CategoriaValidation<T>: AbstractValidator<T> where T : CategoriaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNome()
        {
            RuleFor(d => d.Nome)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do nome")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
        protected void ValidateDescricao()
        {
            RuleFor(d => d.Descricao)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo da descricao")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
    
    }
}
