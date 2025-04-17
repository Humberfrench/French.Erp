using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class TipoDePessoaRepository : BaseRepository<TipoDePessoa>, ITipoDePessoaRepository, IBaseRepository<TipoDePessoa>
    {
        public TipoDePessoaRepository(IMyContextManager<ThisDatabase<TipoDePessoa>> contextManager) : base(contextManager)
        {

        }
    }
}
