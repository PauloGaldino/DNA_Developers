using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Common.Fornecedores
{
   public class FornecedorRemovedEvent : Event
    {
        public FornecedorRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
