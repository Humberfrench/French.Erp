using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITributoService 
    {
        Task<ValidationResult> Gravar(Tributo tributo);
        Task<ValidationResult> Excluir(int id);
    }
}
