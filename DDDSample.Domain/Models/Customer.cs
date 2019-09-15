using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Models
{
    public class Customer : Entity
    {
        public Customer(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        protected Customer() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
