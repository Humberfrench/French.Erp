using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface ITarefaItemService : IBaseService<TarefaItem>
    {
        Task<ValidationResult> Gravar(TarefaItem tarefa);
        Task<ValidationResult> Excluir(int id);
        new Task<IEnumerable<TarefaItem>> ObterTodos();
        new Task<TarefaItem> ObterPorId(int id);
        Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int clienteId);

    }
}
