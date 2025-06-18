using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IFeriadoService
    {
        Task<ValidationResult> Gravar(FeriadoDto leafDto);
        Task<FeriadoDto> ObterPorId(int id);
        Task<List<FeriadoDto>> ObterTodos();
        Task<List<FeriadoDto>> ObterFixos();
        Task<List<FeriadoDto>> ObterLocais();
        Task<List<FeriadoDto>> ObterMoveis(int ano = 0);
    }
}
