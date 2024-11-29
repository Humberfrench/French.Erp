using Dapper;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(IContextManager contextManager) : base(contextManager)
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
