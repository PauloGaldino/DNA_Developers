using DNA.Domain.Commands.Cadastros.Producao.Produto;
using FluentValidation;
using System;

namespace DNA.Domain.Validations.Cadastros.Producao.Produto
{
    public abstract class CategoriaValidation<T>: AbstractValidator<T> where T : CategoriaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateDescricao()
        {
            RuleFor(d => d.Descricao)
            .NotEmpty().WithMessage("Verifique se vc digitou o capo da descricao")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
    
    }
}
