using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using French.Erp.Application.DataObject;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDeClienteService 
    {
        Task<ValidationResult> Gravar(TipoDeClienteDto tipoDeCliente);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TipoDeClienteDto>> ObterTodos();

    }
}
