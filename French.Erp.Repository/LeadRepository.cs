using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class LeadRepository : BaseRepository<Lead>, ILeadRepository, IBaseRepository<Lead>
    {
        public LeadRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
