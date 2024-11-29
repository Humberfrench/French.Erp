using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITarefaItemService 
    {
        Task<ValidationResult> Gravar(TarefaItem tarefa);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TarefaItem>> ObterTodos();
        Task<TarefaItem> ObterPorId(int id);
        Task<IEnumerable<TarefaItem>> ObterTodosItensDaTarefa(int clienteId);

    }
}
