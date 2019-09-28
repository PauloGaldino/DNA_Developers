using DNA.Application.EventSourcedNormalizers.Cadasrtro.Common.Fornecedores;
using DNA.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNA.Application.EventSourcedNormalizers.Cadastro.Common.Fornecedores
{
    public class FornecedorHistory
    {

        public static IList<FornecedorHistoryData> HistoryData { get; set; }

        public static IList<FornecedorHistoryData> ToJavaScriptFornecedorHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<FornecedorHistoryData>();
            FornecedorHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<FornecedorHistoryData>();
            var last = new FornecedorHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new FornecedorHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    NomeCompanhia = string.IsNullOrWhiteSpace(change.NomeCompanhia) || change.NomeCompanhia == last.NomeCompanhia
                        ? ""
                        : change.NomeCompanhia,
                    NomeContato = string.IsNullOrWhiteSpace(change.NomeContato) || change.NomeContato == last.NomeContato
                    ? ""
                    : change.NomeContato,
                    Telefone = string.IsNullOrWhiteSpace(change.Telefone)|| change.Telefone == last.Telefone 
                    ? ""
                    :change.Telefone,
                    TituloContato = string.IsNullOrWhiteSpace(change.TituloContato) || change.TituloContato == last.TituloContato
                    ? ""
                    : change.TituloContato,
                    EnderecoEmail = string.IsNullOrWhiteSpace(change.EnderecoEmail) || change.EnderecoEmail == last.EnderecoEmail
                    ? ""
                    : change.EnderecoEmail,
                    Endereco = string.IsNullOrWhiteSpace(change.Endereco) || change.Endereco == last.Endereco
                    ? ""
                    : change.Endereco,
                    Cidade = string.IsNullOrWhiteSpace(change.Cidade) || change.Cidade == last.Cidade
                    ? ""
                    : change.Cidade,
                    Estado = string.IsNullOrWhiteSpace(change.Estado) || change.Estado == last.Estado
                    ? ""
                    : change.Estado,
                    Pais = string.IsNullOrWhiteSpace(change.Pais) || change.Pais == last.Pais
                    ? ""
                    : change.Pais,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void FornecedorHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new FornecedorHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "FornecedorRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.NomeCompanhia = values["NomeCompanhia"];
                        slot.NomeContato = values["NomeContato"];
                        slot.TituloContato = values["TituloContato"];
                        slot.Telefone = values["Telefone"];
                        slot.EnderecoEmail = values["EnderecoEmail"];
                        slot.Endereco = values["Endereco"];
                        slot.Cidade = values["Cidade"];
                        slot.Estado = values["Estado"];
                        slot.Pais = values["Pais"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "FornecedorUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.NomeCompanhia = values["NomeCompanhia"];
                        slot.NomeContato = values["NomeContato"];
                        slot.TituloContato = values["TituloContato"];
                        slot.Telefone = values["Telefone"];
                        slot.EnderecoEmail = values["EnderecoEmail"];
                        slot.Endereco = values["Endereco"];
                        slot.Cidade = values["Cidade"];
                        slot.Estado = values["Estado"];
                        slot.Pais = values["Pais"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "FornecedorRemovedEvent":
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
