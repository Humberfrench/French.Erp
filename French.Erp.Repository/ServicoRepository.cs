using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository, IBaseRepository<Servico>
    {
        public ServicoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
