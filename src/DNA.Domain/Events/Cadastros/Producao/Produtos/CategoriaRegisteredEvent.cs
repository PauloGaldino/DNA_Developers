using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Producao.Produtos
{
    public class CategoriaRegisteredEvent : Event
    {
        public CategoriaRegisteredEvent(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            AggregateId = id;
        }
        public Guid Id { get; set; }
        public string Descricao { get;private set; }

    }
}
