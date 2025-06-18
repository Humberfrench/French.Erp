using Dapper;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class FaturamentoRepository : BaseRepository<Faturamento>, IFaturamentoRepository, IBaseRepository<Faturamento>
    {
        public FaturamentoRepository(IMyContextManager<ThisDatabase<Faturamento>> contextManager) : base(contextManager)
        {

        }

        public async Task<List<FaturamentoDadosDto>> Obter(int usuario,
                                                   int cliente = 0,
                                                   int mes = 0,
                                                   int ano = 0,
                                                   bool faturado = true)
        {
            var sql = $@"SELECT	f.FaturamentoId, f.ClienteId, f.Ano, f.Mes, f.Valor, 
		                        f.Faturado, f.UsuarioId , c.Nome as Cliente
                        FROM	Faturamento f
                        JOIN	Cliente c
                        ON		f.ClienteId = c.ClienteId 
                        WHERE   f.UsuarioId = {usuario}";
            if (cliente > 0)
            {
                sql += " AND Cliente = @cliente";
            }
            if (mes > 0)
            {
                sql += " AND Mes = @mes";
            }
            if (ano > 0)
            {
                sql += " AND Ano = @ano";
            }
            if (faturado)
            {
                sql += " AND Faturado = 1";
            }
            sql += " ORDER BY Ano, Mes, Cliente";
            var result = await Connection.QueryAsync<FaturamentoDadosDto>(sql);

            return result.ToList();
        }
    }
}
