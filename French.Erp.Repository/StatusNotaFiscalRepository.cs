using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class StatusNotaFiscalRepository : BaseRepository<StatusNotaFiscal>, IStatusNotaFiscalRepository, IBaseRepository<StatusNotaFiscal>
    {
        public StatusNotaFiscalRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
