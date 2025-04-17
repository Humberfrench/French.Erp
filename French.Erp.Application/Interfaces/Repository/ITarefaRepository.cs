using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dietcode.Database.Domain;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        new Task<IEnumerable<Tarefa>> ObterTodos();
        new Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId);
    }
}
