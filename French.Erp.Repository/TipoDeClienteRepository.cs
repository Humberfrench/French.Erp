using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TipoDeClienteRepository : BaseRepository<TipoDeCliente>, ITipoDeClienteRepository
    {
        public TipoDeClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
