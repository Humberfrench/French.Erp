using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
