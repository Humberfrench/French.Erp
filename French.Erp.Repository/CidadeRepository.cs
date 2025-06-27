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
    public class CidadeRepository : BaseRepository<Cidade, int>, ICidadeRepository, IBaseRepository<Cidade, int>
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
