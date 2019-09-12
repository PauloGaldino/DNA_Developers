using DNA.Domain.Core.Events;
using DNA.Domain.Core.Events.Interfaces;
using DNA.Domain.Interfaces.Cadastros.Pessoas.Usuarios;
using DNA.Infra.Data.Repository.EventSourcing.Interfaces;
using Newtonsoft.Json;

namespace DNA.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Nome);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}