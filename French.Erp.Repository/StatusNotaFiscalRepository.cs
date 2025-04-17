using Dietcode.Database.Domain;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;

namespace French.Erp.Repository
{
    public class StatusNotaFiscalRepository : BaseRepository<StatusNotaFiscal>, IStatusNotaFiscalRepository, IBaseRepository<StatusNotaFiscal>
    {
        public StatusNotaFiscalRepository(IMyContextManager<ThisDatabase<StatusNotaFiscal>> contextManager) : base(contextManager)
        {

        }
    }
}
