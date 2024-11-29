using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface ITarefaItemRepository
    {
        Task<IEnumerable<TarefaItem>> ObterTodos();
        Task<TarefaItem> ObterPorId(int id);
        Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int clienteId);
    }
}
