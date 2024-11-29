using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TributoRepository : BaseRepository<Tributo>, ITributoRepository
    {
        public TributoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
