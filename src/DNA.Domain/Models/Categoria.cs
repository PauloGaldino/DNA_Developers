using DNA.Domain.Core.Models;
using System;

namespace DNA.Domain.Models
{
    public class Categoria : Entity
    {
        public Categoria(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        protected Categoria(){}

        public string Nome { get; private set; }
        public string Descricao { get; private set; }

    }
}
