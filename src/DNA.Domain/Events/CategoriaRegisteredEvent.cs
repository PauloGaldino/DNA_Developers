using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events
{
    public class CategoriaRegisteredEvent : Event
    {
        public CategoriaRegisteredEvent(Guid id,string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get;private set; }

    }
}
