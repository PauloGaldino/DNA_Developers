using DNA.Domain.Core.Events;
using System;

namespace DNA.Domain.Events.Cadastros.Common.Expedidores
{
   public  class ExpedidorUpdatedEvent : Event
    {
        public ExpedidorUpdatedEvent(Guid id, string companhiaNome, string telefone)
        {
            Id = id;
            CompnhiaNome = companhiaNome;
            Telefone = telefone;
        }

        public Guid Id { get; set; }
        public string CompnhiaNome { get; private set; }
        public string Telefone { get;private set; }
    }
}
