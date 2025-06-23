using Dapper;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.DataObject;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository, IBaseRepository<Tarefa>
    {
        public TarefaRepository(IMyContextManager<ThisDatabase<Tarefa>> context) : base(context)
        {


        }

        public async Task<IEnumerable<ClienteDadosDto>> ObterTodosClientes()
        {
            var sql = $@"SELECT	distinct c.ClienteId , c.Nome, c.RazaoSocial
                            FROM	Tarefa t
                            JOIN	Cliente c
                            ON		t.ClienteId = c.ClienteId
                            ORDER BY Nome";
            var query = await Connection.QueryAsync<ClienteDadosDto>(sql);

            return query.ToList();

        }

        public new async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await this.DbSet.Include(t => t.Cliente)
                                   .Include(t => t.TarefaItems)
                                   .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId)
        {
            return await this.DbSet.Include(t => t.Cliente)
                                   .Include(t => t.TarefaItems)
                                   .Where(c => c.ClienteId == clienteId)
                                   .ToListAsync();
            
        }
        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId, int ano, int mes)
        {
            var dados = this.DbSet.Include(t => t.Cliente)
                                  .Include(t => t.TarefaItems)
                                  .Where(c => c.ClienteId == clienteId
                                      && c.DataInicio.Year == ano
                                      &&  c.DataInicio.Month == mes);

            return await dados.ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId, int ano)
        {
            var dados = this.DbSet.Include(t => t.Cliente)
                                  .Include(t => t.TarefaItems)
                                  .Where(c => c.ClienteId == clienteId
                                      && c.DataInicio.Year == ano);

            return await dados.ToListAsync();
        }

        public new async Task<Tarefa> ObterPorId(int id)
        {

            return await this.DbSet.Include(t => t.Cliente)
                                   .Include(t => t.TarefaItems)
                                   .FirstOrDefaultAsync(c => c.TarefaId == id);
        }

    }
}
