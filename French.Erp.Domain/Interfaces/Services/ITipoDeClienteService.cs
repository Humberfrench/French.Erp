using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface ITipoDeClienteService : IBaseService<TipoDeCliente>
    {
        Task<ValidationResult> Gravar(TipoDeCliente tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
    }
}
