using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class StatusNotaFiscalRepository : BaseRepository<StatusNotaFiscal, byte>, IStatusNotaFiscalRepository, IBaseRepository<StatusNotaFiscal, byte>
    {
        public StatusNotaFiscalRepository(IMyContextManager<ThisDatabase<StatusNotaFiscal>> contextManager) : base(contextManager)
        {

        }
    }
}
