using DNA.Domain.Core.Models;
using System;

namespace DNA.Domain.Models.Cadastros.Common.Fornecedores
{
    public class Fornecedor : Entity
    {
        public Fornecedor( Guid id, string nomeCompanhia, string nomeContato,string tituloContato,string telefone,string enderecoEmail, string endereco,string cidade,string estado, string pais)
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

        protected Fornecedor()
        {

        }
        public string NomeCompanhia { get;private set; }
        public string NomeContato { get; private set; }
        public string TituloContato { get; private set; }
        public string Telefone { get; private set; }
        public string EnderecoEmail { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
    }
}
