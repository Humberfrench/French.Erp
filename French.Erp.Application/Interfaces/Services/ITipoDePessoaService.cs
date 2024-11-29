using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using French.Erp.Application.DataObject;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDePessoaService 
    {
        Task<ValidationResult> Gravar(TipoDePessoaDto tipoDePessoa);
        Task<ValidationResult> Excluir(int id);
        Task<IEnumerable<TipoDePessoaDto>> ObterTodos();
        Task<TipoDePessoaDto> ObterPorId(int id);
    }
}
