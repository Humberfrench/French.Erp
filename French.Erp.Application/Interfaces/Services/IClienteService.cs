using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ValidationResult> Gravar(ClienteDto cliente);
        Task<ValidationResult<bool>> Excluir(int id);
        Task<IEnumerable<ClienteDto>> ObterTodos();
        Task<ClienteDto> ObterPorId(int id);
        Task<IEnumerable<ClienteDadosDto>> ObterTodosParaCombo();
    }
}
