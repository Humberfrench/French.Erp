using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface IStatusNotaFiscalService : IBaseService<StatusNotaFiscal>
    {
        Task<ValidationResult> Gravar(StatusNotaFiscal tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
    }
}
