using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events
{
    public class CategoriaUpdatedEvent :Event
    {
        public CategoriaUpdatedEvent(Guid id,string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; private set; }

    }
}

