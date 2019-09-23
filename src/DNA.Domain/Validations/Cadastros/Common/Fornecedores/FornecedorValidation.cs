using DNA.Domain.Commands.Cadastros.Common.Fornecedores;
using FluentValidation;
using System;

namespace DNA.Domain.Validations.Cadastros.Common.Fornecedores
{
    public abstract class FornecedorValidation<T> : AbstractValidator<T> where T : FornecedorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateNomeCompanhia()
        {
            RuleFor(f => f.NomeCompanhia)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do nome da companhia")
            .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
        protected void ValidateNomeContato()
        {
            RuleFor(f => f.NomeContato)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do nome do contato")
            .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
        protected void ValidateTituloContato()
        {
            RuleFor(f =>f.TituloContato )
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do Titulo do contato")
            .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }
        protected void ValidateTelefone()
        {
            RuleFor(f => f.Telefone)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do Telefone")
            .Length(2, 50).WithMessage("O nome deve ter entre 2 e 50 caracteres.");
        }
        protected void ValidateEmail()
        {
            RuleFor(c => c.EnderecoEmail)
                  .NotEmpty()
                  .EmailAddress();
        }
        protected void ValidateCidade()
        {
            RuleFor(f => f.Cidade)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo da Cidade")
            .Length(2, 200).WithMessage("O nome deve ter entre 2 e 200 caracteres.");
        }

        protected void ValidateEstado()
        {
            RuleFor(f => f.Estado)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do Estado")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }
        protected void ValidatePais()
        {
            RuleFor(f => f.Pais)
            .NotEmpty().WithMessage("Verifique se vc digitou o campo do Pais")
            .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");
        }
    }
}
