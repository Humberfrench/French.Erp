using Dapper;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository, IBaseRepository<Estado>
    {
        public EstadoRepository(IMyContextManager<ThisDatabase<Estado>> contextManager) : base(contextManager)
        {

        }
        public async new Task<IEnumerable<Estado>> ObterTodos()
        {
            var sql = $"SELECT * FROM Estado ORDER BY NomeUf";
            var query = await Task.Run(() => Connection.Query<Estado>(sql));

            return query;

        }
    }
}