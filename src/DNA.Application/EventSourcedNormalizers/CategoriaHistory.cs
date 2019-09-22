using DNA.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNA.Application.EventSourcedNormalizers
{
    public class CategoriaHistory
    {
        public static IList<CategoriaHistoryData> HistoryData { get; set; }

        public static IList<CategoriaHistoryData>ToJavaScriptCategoriaHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CategoriaHistoryData>();
            CategoriaHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CategoriaHistoryData>();
            var last = new CategoriaHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CategoriaHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                 
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CategoriaHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CategoriaHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CategoriaRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.Nome = values["Nome"];
                        slot.Nome = values["Descricao"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CategoriaUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Nome = values["Descicao"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "CategoriaRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}

