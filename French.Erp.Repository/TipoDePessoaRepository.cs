using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class TipoDePessoaRepository : BaseRepository<TipoDePessoa, byte>, ITipoDePessoaRepository, IBaseRepository<TipoDePessoa, byte>
    {
        public TipoDePessoaRepository(IMyContextManager<ThisDatabase<TipoDePessoa>> contextManager) : base(contextManager)
        {

        }
    }
}
