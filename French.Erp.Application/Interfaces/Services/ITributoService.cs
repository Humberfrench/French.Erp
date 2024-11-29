using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface ITributoService : IBaseService<Tributo>
    {
        Task<ValidationResult> Gravar(Tributo tributo);
        Task<ValidationResult> Excluir(int id);
    }
}
