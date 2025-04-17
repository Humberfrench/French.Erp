using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class TributoRepository : BaseRepository<Tributo>, ITributoRepository, IBaseRepository<Tributo>
    {
        public TributoRepository(IMyContextManager<ThisDatabase<Tributo>> contextManager) : base(contextManager)
        {

        }
    }
}
