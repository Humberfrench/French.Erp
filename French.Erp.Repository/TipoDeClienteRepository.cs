using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class TipoDeClienteRepository : BaseRepository<TipoDeCliente>, ITipoDeClienteRepository, IBaseRepository<TipoDeCliente>
    {
        public TipoDeClienteRepository(IMyContextManager<ThisDatabase<TipoDeCliente>> contextManager) : base(contextManager)
        {

        }
    }
}
