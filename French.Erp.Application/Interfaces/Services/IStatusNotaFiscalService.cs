using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IStatusNotaFiscalService
    {
        Task<ValidationResult> Gravar(StatusNotaFiscalDto tipoDeCliente);
        Task<ValidationResult> Excluir(byte id);

        Task<StatusNotaFiscalDto> ObterPorId(byte id);
        Task<List<StatusNotaFiscalDto>> ObterTodos();
    }
}
