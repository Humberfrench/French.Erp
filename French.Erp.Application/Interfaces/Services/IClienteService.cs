using Dietcode.Core.DomainValidator;
using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using French.Erp.Application.DataObject;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ValidationResult> Gravar(Cliente tributo);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<IEnumerable<ClienteDadosDto>> ObterTodosParaCombo();
    }
}
