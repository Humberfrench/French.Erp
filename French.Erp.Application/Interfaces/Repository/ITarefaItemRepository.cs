using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ITarefaItemRepository : IBaseRepository<TarefaItem, int>
    {
        new Task<IEnumerable<TarefaItem>> ObterTodos();
        new Task<TarefaItem> ObterPorId(int id);
        Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int clienteId);
    }
}
