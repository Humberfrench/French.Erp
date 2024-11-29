using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TipoDeClienteRepository : BaseRepository<TipoDeCliente>, ITipoDeClienteRepository, IBaseRepository<TipoDeCliente>
    {
        public TipoDeClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
