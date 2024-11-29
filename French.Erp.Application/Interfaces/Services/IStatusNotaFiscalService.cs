using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using French.Erp.Application.DataObject;
using System.Collections.Generic;

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
