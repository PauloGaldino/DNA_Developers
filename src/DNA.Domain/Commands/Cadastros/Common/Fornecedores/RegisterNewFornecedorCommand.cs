using DNA.Domain.Validations.Cadastros.Common.Fornecedores;

namespace DNA.Domain.Commands.Cadastros.Common.Fornecedores
{
    public class RegisterNewFornecedorCommand : FornecedorCommand
    {
        public RegisterNewFornecedorCommand(string nomeCompanhia, string nomeContato, string tituloContato, string telefone, string enderecoEmail, string endereco, string cidade, string estado, string pais)
        {

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
            ValidationResult = new RegisterNewFornecedorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
