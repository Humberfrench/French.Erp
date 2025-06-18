using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class LeadRepository : BaseRepository<Lead>, ILeadRepository, IBaseRepository<Lead>
    {
        public LeadRepository(IMyContextManager<ThisDatabase<Lead>> contextManager) : base(contextManager)
        {

        }
    }
}
