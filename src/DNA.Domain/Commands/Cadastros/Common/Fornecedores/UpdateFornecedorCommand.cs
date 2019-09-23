using DNA.Domain.Validations.Cadastros.Common.Fornecedores;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Fornecedores
{
    public class UpdateFornecedorCommand : FornecedorCommand
    {

        public UpdateFornecedorCommand(Guid id, string nomeCompanhia, string nomeContato, string tituloContato, string telefone, string enderecoEmail, string endereco, string cidade, string estado, string pais)
        {
            Id = id;
            NomeCompanhia = nomeCompanhia;
            NomeContato = nomeContato;
            TituloContato = tituloContato;
            Telefone = telefone;
            EnderecoEmail = enderecoEmail;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFornecedorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
