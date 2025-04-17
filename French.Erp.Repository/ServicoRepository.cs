using Dietcode.Database.Domain;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;

namespace French.Erp.Repository
{
    public class ServicoRepository : BaseRepository<Servico>, IServicoRepository, IBaseRepository<Servico>
    {
        public ServicoRepository(IMyContextManager<ThisDatabase<Servico>> contextManager) : base(contextManager)
        {

        }
    }
}
