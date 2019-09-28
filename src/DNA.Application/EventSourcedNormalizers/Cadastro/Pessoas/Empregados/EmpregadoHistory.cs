using DNA.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Pessoas.Empregados
{
    public class EmpregadoHistory
    {
        public static IList<EmpregadoHistoryData> HistoryData { get; set; }

        public static IList<EmpregadoHistoryData> ToJavaScriptEmpregadoHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<EmpregadoHistoryData>();
            EmpregadoHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<EmpregadoHistoryData>();
            var last = new EmpregadoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new EmpregadoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Sobrenome = string.IsNullOrWhiteSpace(change.Sobrenome) || change.Sobrenome == last.Sobrenome
                        ? ""
                        : change.Sobrenome,
                    Cargo = string.IsNullOrWhiteSpace(change.Cargo) || change.Cargo == last.Cargo
                        ? ""
                        : change.Cargo,
                    DataAdmissao = string.IsNullOrWhiteSpace(change.DataAdmissao) || change.DataAdmissao == last.DataAdmissao
                        ? ""
                        : change.DataAdmissao.Substring(0, 10),
                    DataNascimento = string.IsNullOrWhiteSpace(change.DataNascimento) || change.DataNascimento == last.DataNascimento
                        ? ""
                        : change.DataNascimento.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void EmpregadoHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new EmpregadoHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "EmpregadoRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Sobrenome = values["Sobrenome"];
                        slot.Cargo = values["Cargo"];
                        slot.DataAdmissao = values["DataAdmissao"];
                        slot.DataNascimento = values["DataNascimento"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "EmpregadoUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Sobrenome = values["Sobrenome"];
                        slot.Cargo = values["Cargo"];
                        slot.DataAdmissao = values["DataAdmissao"];
                        slot.DataNascimento = values["DataNascimento"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "EmpregadoRemovedEvent":
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