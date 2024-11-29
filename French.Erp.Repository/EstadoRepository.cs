using Dapper;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(IContextManager contextManager) : base(contextManager)
        {

        }
        new public async Task<IEnumerable<Estado>> ObterTodos()
        {
            var sql = $"SELECT * FROM Estado ORDER BY NomeUf";
            var query = await Task.Run(() => Connection.Query<Estado>(sql));

            return query;

        }
    }
}