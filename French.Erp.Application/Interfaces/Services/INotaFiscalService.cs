using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface INotaFiscalService : IBaseService<NotaFiscal>
    {
        Task<ValidationResult> Gravar(NotaFiscal tributo);
        Task<ValidationResult> Excluir(int id);
    }
}
