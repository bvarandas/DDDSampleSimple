using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Models;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DDDSample.Infra.Data.Context;

namespace DDDSample.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DDDSampleContext context): 
            base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
