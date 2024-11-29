using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface ITarefaService : IBaseService<Tarefa>
    {
        Task<ValidationResult> Gravar(Tarefa tarefa);
        Task<ValidationResult> Excluir(int id);
        new Task<IEnumerable<Tarefa>> ObterTodos();
        new Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId);
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
