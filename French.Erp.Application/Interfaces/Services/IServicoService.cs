using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using French.Erp.Application.DataObject;
using System.Collections.Generic;

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
