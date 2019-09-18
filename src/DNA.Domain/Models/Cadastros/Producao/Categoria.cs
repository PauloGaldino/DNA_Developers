using DNA.Domain.Core.Models;
using System;

namespace DNA.Domain.Models.Cadastros.Producao
{
    public class Categoria : Entity
    {
        public Categoria(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
        protected Categoria(){}
        public string Descricao { get; private set; }


    }
}
