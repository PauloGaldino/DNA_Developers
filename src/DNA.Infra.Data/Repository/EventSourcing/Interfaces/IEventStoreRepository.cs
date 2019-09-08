using DNA.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace DNA.Infra.Data.Repository.EventSourcing.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}