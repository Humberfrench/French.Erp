using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class StatusNotaFiscalRepository : BaseRepository<StatusNotaFiscal>, IStatusNotaFiscalRepository
    {
        public StatusNotaFiscalRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
