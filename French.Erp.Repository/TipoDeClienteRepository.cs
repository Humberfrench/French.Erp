using Dietcode.Database.Domain;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;

namespace French.Erp.Repository
{
    public class TipoDeClienteRepository : BaseRepository<TipoDeCliente>, ITipoDeClienteRepository, IBaseRepository<TipoDeCliente>
    {
        public TipoDeClienteRepository(IMyContextManager<ThisDatabase<TipoDeCliente>> contextManager) : base(contextManager)
        {

        }
    }
}
