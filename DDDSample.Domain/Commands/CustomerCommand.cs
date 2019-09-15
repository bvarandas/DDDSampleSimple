using System;
using System.Collections.Generic;
using System.Text;
using DDDSample.Domain.Core.Commands;

namespace DDDSample.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}
