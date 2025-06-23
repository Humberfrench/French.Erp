using Dietcode.Database.Domain;
using French.Erp.Application.DataObject;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        new Task<IEnumerable<Tarefa>> ObterTodos();
        Task<IEnumerable<ClienteDadosDto>> ObterTodosClientes();
        new Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId, int ano, int mes);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId, int ano);
    }
}
