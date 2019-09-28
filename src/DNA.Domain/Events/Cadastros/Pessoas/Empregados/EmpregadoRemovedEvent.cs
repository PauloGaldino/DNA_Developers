using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Pessoas.Empregados
{
    public class EmpregadoRemovedEvent : Event
    {
        public EmpregadoRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
