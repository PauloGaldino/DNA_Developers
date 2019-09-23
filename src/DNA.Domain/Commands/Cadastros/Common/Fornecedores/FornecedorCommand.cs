using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands.Cadastros.Common.Fornecedores
{
    public abstract class FornecedorCommand : Command
    {
        public Guid Id { get; protected set; }
        public string NomeCompanhia { get; protected set; }
        public string NomeContato { get; protected set; }
        public string TituloContato { get; protected set; }
        public string Telefone { get; protected set; }
        public string EnderecoEmail { get; protected set; }
        public string Endereco { get; protected set; }
        public string Cidade { get; protected set; }
        public string Estado { get; protected set; }
        public string Pais { get; protected set; }
    }
}
