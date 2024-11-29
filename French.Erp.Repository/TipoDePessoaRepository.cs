using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TipoDePessoaRepository : BaseRepository<TipoDePessoa>, ITipoDePessoaRepository
    {
        public TipoDePessoaRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
