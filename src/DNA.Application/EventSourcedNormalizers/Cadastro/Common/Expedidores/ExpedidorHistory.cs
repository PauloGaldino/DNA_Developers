using DNA.Application.EventSourcedNormalizers.Cadastro.Common.Fornecedores;
using DNA.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Common.Expedidores
{
    public class ExpedidorHistory
    {
        public static IList<ExpedidorHistoryData> HistoryData { get; set; }

        public static IList<ExpedidorHistoryData> ToJavaScriptExpedidorHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ExpedidorHistoryData>(); 
            ExpedidorHistoryDeserializer(storedEvents);

          

            var sorted = HistoryData.OrderBy(e => e.When);
            var list = new List<ExpedidorHistoryData>();
            var last = new ExpedidorHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ExpedidorHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    CompanhiaNome = string.IsNullOrWhiteSpace(change.CompanhiaNome) || change.CompanhiaNome == last.CompanhiaNome
                        ? ""
                        : change.CompanhiaNome,
                   
                    Telefone = string.IsNullOrWhiteSpace(change.Telefone) || change.Telefone == last.Telefone
                    ? ""
                    : change.Telefone,
                   
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ExpedidorHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ExpedidorHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ExpedidorRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.CompanhiaNome = values["CompanhiaNome"];
                        slot.Telefone = values["Telefone"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "ExpedidorUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.CompanhiaNome = values["CompanhiaNome"];
                        slot.Telefone = values["Telefone"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "ExpedidorRemovedEvent":
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
