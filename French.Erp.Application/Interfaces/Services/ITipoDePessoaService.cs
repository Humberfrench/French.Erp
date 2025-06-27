using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDePessoaService
    {
        Task<ValidationResult> Gravar(TipoDePessoaDto tipoDePessoa);
        Task<ValidationResult> Excluir(byte id);
        Task<IEnumerable<TipoDePessoaDto>> ObterTodos();
        Task<TipoDePessoaDto> ObterPorId(byte id);
    }
}
