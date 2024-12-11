using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ILeadService
    {
        Task<ValidationResult> Gravar(LeadDto leafDto);
        Task<ValidationResult> CriarCliente(int id);

        Task<LeadDto> ObterPorId(int id);
        Task<List<LeadDto>> ObterTodos();
    }
}
