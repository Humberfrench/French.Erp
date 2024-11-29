using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDeClienteService 
    {
        Task<ValidationResult> Gravar(TipoDeCliente tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
    }
}
