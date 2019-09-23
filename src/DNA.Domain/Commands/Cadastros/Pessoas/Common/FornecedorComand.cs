using DNA.Domain.Core.Commands;
using System;

namespace DNA.Domain.Commands.Cadastros.Pessoas.Common
{
    public abstract class FornecedorComand : Command
    {
        public Guid Id { get; set; }
        public string NomeCompania { get; private set; }
        public string NomeContato { get; private set; }
        public string TituloContato { get; private set; }
        public string Telefone { get; set; }
        public string EnderecoEmail { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Regiao { get; set; }
        public string Pais { get; set; }
    }
}
