using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Pessoas.Clientes
{
    public class ClienteRemovedEvent : Event
    {
        public ClienteRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}