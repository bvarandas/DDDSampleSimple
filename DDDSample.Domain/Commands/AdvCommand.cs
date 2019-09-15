using System;
using DDDSample.Domain.Core.Commands;

namespace DDDSample.Domain.Commands
{
    public abstract class AdvCommand :  Command
    {
        public int ID { get; protected set; }

        public string Marca { get; protected set; }

        public string Modelo { get; protected set; }

        public string Versao { get; protected set; }

        public int Ano { get; protected set; }

        public int Quilometragem { get; protected set; }

        public string Observacao { get; protected set; }
    }
}
