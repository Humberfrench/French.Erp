using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class TarefaItemRepository : BaseRepository<TarefaItem, int>, ITarefaItemRepository, IBaseRepository<TarefaItem, int>
    {
        public TarefaItemRepository(IMyContextManager<ThisDatabase<TarefaItem>> context) : base(context)
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
