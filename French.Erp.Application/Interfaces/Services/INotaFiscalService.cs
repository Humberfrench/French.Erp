using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using French.Erp.Application.ViewModel;
using System.Collections.Generic;

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
