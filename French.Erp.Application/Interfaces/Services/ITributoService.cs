using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using French.Erp.Application.DataObject;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITributoService 
    {
        Task<ValidationResult> Gravar(TributoDto tributo);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TributoDto>> ObterTodos();
        Task<TributoDto> ObterPorId(int id);
    }
}
