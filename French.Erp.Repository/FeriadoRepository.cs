using Dapper;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class FeriadoRepository : BaseRepository<Feriado>, IFeriadoRepository, IBaseRepository<Feriado>
    {
        public FeriadoRepository(IMyContextManager<ThisDatabase<Feriado>> contextManager) : base(contextManager)
        {

        }

        public async Task<List<Feriado>> ObterFeriadosMes(int mes)
        {
            var sql = $@"SELECT	FeriadoId, Nome, Dia, Mes, Ano, CidadeId, EstadoId
                         FROM	Feriado
                         WHERE	Mes = {mes}";

            var query = (await Connection.QueryAsync<Feriado>(sql)).ToList();

            return query;
        }
    }
}
