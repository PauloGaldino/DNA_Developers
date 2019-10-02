using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Common.Expedidores
{
    public class ExpedidorRegisteredEvent : Event
    {
        public ExpedidorRegisteredEvent(Guid id, string companhiaNome, string telefone )
        {
            Id = id;
            CompanhiaNome = companhiaNome;
            Telefone = telefone;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string CompanhiaNome { get; private set; }
        public string Telefone { get;private set; }
    }
}
