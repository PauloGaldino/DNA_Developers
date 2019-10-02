using DNA.Domain.Core.Models;
using DNA.Domain.Core.Models.Pessoas;
using System;

namespace DNA.Domain.Models.Cadastros.Pessoas
{
    public class Empregado : Entity
    {
        public Empregado(Guid id, string nome, string sobrenome, string cargo, DateTime dataAdmissao, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Cargo = cargo;
            DataAdmissao = dataAdmissao;
            DataNascimento = DataNascimento;
        }
        protected Empregado() { }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Cargo { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public DateTime DataNascimento { get; private set; }
    }
}
