using Dietcode.Database.Domain;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;

namespace French.Erp.Repository
{
    public class LeadRepository : BaseRepository<Lead>, ILeadRepository, IBaseRepository<Lead>
    {
        public LeadRepository(IMyContextManager<ThisDatabase<Lead>> contextManager) : base(contextManager)
        {

        }
    }
}
