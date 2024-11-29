using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TributoRepository : BaseRepository<Tributo>, ITributoRepository, IBaseRepository<Tributo>
    {
        public TributoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
