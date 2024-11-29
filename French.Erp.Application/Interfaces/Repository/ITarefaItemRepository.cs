using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ITarefaItemRepository : IBaseRepository<TarefaItem>
    {
        new Task<IEnumerable<TarefaItem>> ObterTodos();
        new Task<TarefaItem> ObterPorId(int id);
        Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int clienteId);
    }
}
