using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public new async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItem)
                                                  .ThenInclude(c => c.Tarefa.TarefaItem)
                                                  .ToList());
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId)
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItem)
                                                  .ThenInclude(c => c.Tarefa.TarefaItem)
                                                  .Where(c => c.ClienteId == clienteId)
                                                  .ToList());
        }

        public new async Task<Tarefa> ObterPorId(int id)
        {

            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItem)
                                                  .ThenInclude(c => c.Tarefa.TarefaItem)
                                                  .FirstOrDefaultAsync(c => c.TarefaId == id));
        }

    }
}
