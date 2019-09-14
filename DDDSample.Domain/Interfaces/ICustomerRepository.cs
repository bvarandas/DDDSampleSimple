using DDDSample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDSample.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
