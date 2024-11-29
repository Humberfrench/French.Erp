using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class TarefaItemRepository : BaseRepository<TarefaItem>, ITarefaItemRepository
    {
        public TarefaItemRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public new async Task<IEnumerable<TarefaItem>> ObterTodos()
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Servico)
                                                  .OrderBy(t => t.Ordem)
                                                  .ToList());
        }

        public async Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int tarefaId)
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Servico)
                                                  .Where(t => t.TarefaId == tarefaId)
                                                  .OrderBy(t => t.Ordem)
                                                  .ToList());
        }

        public new async Task<TarefaItem> ObterPorId(int id)
        {

            return await Task.Run(() => this.DbSet.Include(t => t.Servico)
                                                  .FirstOrDefaultAsync(c => c.TarefaItemId == id));
        }

    }
}
