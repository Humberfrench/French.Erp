using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IStatusNotaFiscalService 
    {
        Task<ValidationResult> Gravar(StatusNotaFiscal tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
    }
}
