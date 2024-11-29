using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using French.Erp.Domain.ObjectValue;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<ValidationResult> Gravar(Cliente tributo);
        Task<ValidationResult> Excluir(int id);
        new Task<IEnumerable<Cliente>> ObterTodos();
        Task<IEnumerable<ClienteDados>> ObterTodosParaCombo();
    }
}
