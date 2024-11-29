using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IServicoService
    {
        Task<ValidationResult> Gravar(ServicoDto servico);
        Task<ValidationResult> Excluir(int id);
        Task<ServicoDto> ObterPorId(int id);
        Task<List<ServicoDto>> ObterTodos();
    }
}
