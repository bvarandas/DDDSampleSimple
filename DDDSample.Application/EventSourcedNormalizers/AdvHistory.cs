using System;
using System.Collections.Generic;
using System.Linq;
using DDDSample.Domain.Core.Events;
using Newtonsoft.Json;

namespace DDDSample.Application.EventSourcedNormalizers
{
    public class AdvHistory
    {
        public static IList<AdvHistoryData> HistoryData { get; set; }

        public static IList<AdvHistoryData> ToJavaScriptAdvHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<AdvHistoryData>();
            AdvHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<AdvHistoryData>();
            var last = new AdvHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new AdvHistoryData
                {
                    ID = change.ID == string.Empty || change.ID == last.ID
                        ? ""
                        : change.ID,
                    Marca  = string.IsNullOrWhiteSpace(change.Marca) || change.Marca == last.Marca ? "" : change.Marca,

                    Modelo = string.IsNullOrWhiteSpace(change.Modelo) || change.Modelo == last.Modelo ? "" : change.Modelo,

                    Versao = string.IsNullOrWhiteSpace(change.Versao) || change.Versao == last.Versao ? "" : change.Versao,

                    Ano    = string.IsNullOrWhiteSpace(change.Ano) || change.Ano == last.Ano ? "" : change.Ano,

                    Quilometragem = string.IsNullOrWhiteSpace(change.Quilometragem) || change.Quilometragem == last.Quilometragem ? "": change.Quilometragem,

                    Observacao = string.IsNullOrWhiteSpace(change.Observacao) || change.Observacao == last.Observacao ? "" : change.Observacao,

                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,

                    When = change.When,

                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void AdvHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new AdvHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "AdvRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Marca = values["Marca"];
                        slot.Modelo= values["Modelo"];
                        slot.Versao = values["Versao"];
                        slot.Versao = values["Versao"];
                        slot.Quilometragem = values["Quilomentragem"];
                        slot.Observacao = values["Observacao"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.ID = values["ID"];
                        slot.Who = e.User;
                        break;
                    case "AdvUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Marca = values["Marca"];
                        slot.Modelo = values["Modelo"];
                        slot.Versao = values["Versao"];
                        slot.Versao = values["Versao"];
                        slot.Quilometragem = values["Quilomentragem"];
                        slot.Observacao = values["Observacao"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.ID = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "AdvRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.ID = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
