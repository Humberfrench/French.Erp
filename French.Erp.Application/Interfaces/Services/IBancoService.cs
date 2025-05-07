using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IBancoService
    {
        Task<ValidationResult> Gravar(BancoDto leafDto);
        Task<ValidationResult> AlterarStatus(int banco, bool status);
        Task<BancoDto> ObterPorId(int id);
        Task<List<BancoDto>> ObterTodos();
    }
}
