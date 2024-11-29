using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodos();
        Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId);
    }
}
