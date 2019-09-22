using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events
{
    public class CategoriaRemovedEvent :Event
    {
        public CategoriaRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
