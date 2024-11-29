using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITarefaService 
    {
        Task<ValidationResult> Gravar(Tarefa tarefa);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Tarefa>> ObterTodos();
        Task<Tarefa> ObterPorId(int id);
        Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId);
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
