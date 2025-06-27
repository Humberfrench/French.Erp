using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDeClienteService
    {
        Task<ValidationResult> Gravar(TipoDeClienteDto tipoDeCliente);
        Task<ValidationResult> Excluir(byte id);
        Task<IEnumerable<TipoDeClienteDto>> ObterTodos();

    }
}
