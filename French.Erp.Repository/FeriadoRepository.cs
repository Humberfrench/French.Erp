using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;

namespace French.Erp.Repository
{
    public class FeriadoRepository : BaseRepository<Feriado>, IFeriadoRepository, IBaseRepository<Feriado>
    {
        public FeriadoRepository(IMyContextManager<ThisDatabase<Feriado>> contextManager) : base(contextManager)
        {

        }
    }
}
