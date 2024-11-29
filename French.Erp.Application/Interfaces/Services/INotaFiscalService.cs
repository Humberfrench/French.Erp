using Dietcode.Core.DomainValidator;
using French.Erp.Application.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface INotaFiscalService
    {
        Task<ValidationResult> Gravar(NotaFiscalDto notaFiscalDados);
        Task<ValidationResult> Excluir(int id);
        Task<NotaFiscalDto> ObterPorId(int id);
        Task<List<NotaFiscalDto>> ObterTodos();
    }
}
