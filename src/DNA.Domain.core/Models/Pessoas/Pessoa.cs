using System;

namespace DNA.Domain.Core.Models.Pessoas
{
    public abstract class Pessoa : Entity
    {
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
    }
}
