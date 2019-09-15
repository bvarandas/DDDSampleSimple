using System;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.Events
{
    public class AdvUpdatedEvent : Event
    {
        public AdvUpdatedEvent(int id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {

        }

        public int ID { get; set; }

        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Versao { get; private set; }

        public int Ano { get; private set; }

        public int Quilometragem { get; private set; }

        public string Observacao { get; private set; }
    }
}
