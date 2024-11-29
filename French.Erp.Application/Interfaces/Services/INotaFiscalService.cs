using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface INotaFiscalService 
    {
        Task<ValidationResult> Gravar(NotaFiscal tributo);
        Task<ValidationResult> Excluir(int id);
    }
}
