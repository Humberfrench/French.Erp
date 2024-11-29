using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;

namespace French.Erp.Repository
{
    public class TipoDePessoaRepository : BaseRepository<TipoDePessoa>, ITipoDePessoaRepository, IBaseRepository<TipoDePessoa>
    {
        public TipoDePessoaRepository(IContextManager contextManager) : base(contextManager)
        {

        }
    }
}
