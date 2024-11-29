using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IStatusNotaFiscalService
    {
        Task<ValidationResult> Gravar(StatusNotaFiscalDto tipoDeCliente);
        Task<ValidationResult> Excluir(int id);

        Task<StatusNotaFiscalDto> ObterPorId(int id);
        Task<List<StatusNotaFiscalDto>> ObterTodos();
    }
}
