using Dapper;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository, IBaseRepository<Cidade>
    {
        public CidadeRepository(IMyContextManager<ThisDatabase<Cidade>> contextManager) : base(contextManager)
        {

        }

        public async Task<IEnumerable<Cidade>> ObterCidades(int uf)
        {
            var sql = $"SELECT * FROM Cidade WHERE EstadoID = {uf} ORDER BY Nome";
            var query = await Task.Run(() => Connection.Query<Cidade>(sql));

            return query;
        }
    }
}
