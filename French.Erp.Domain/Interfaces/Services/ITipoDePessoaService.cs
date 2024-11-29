using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface ITipoDePessoaService : IBaseService<TipoDePessoa>
    {
        Task<ValidationResult> Gravar(TipoDePessoa tipoDePessoa);
        Task<ValidationResult> Excluir(int id);
    }
}
