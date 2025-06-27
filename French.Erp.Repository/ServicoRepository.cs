using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class ServicoRepository : BaseRepository<Servico, int>, IServicoRepository, IBaseRepository<Servico, int>
    {
        public ServicoRepository(IMyContextManager<ThisDatabase<Servico>> contextManager) : base(contextManager)
        {

        }
    }
}
