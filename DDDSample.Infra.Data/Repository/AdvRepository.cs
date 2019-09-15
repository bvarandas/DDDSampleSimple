using System.Linq;
using DDDSample.Domain.Interfaces;
using DDDSample.Domain.Models;
using DDDSample.Infra.Data.Context;

namespace DDDSample.Infra.Data.Repository
{
    public class AdvRepository : Repository<Adv>, IAdvRepository
    {
        public AdvRepository(DDDSampleContext context) : base(context)
        {

        }
    }
}
