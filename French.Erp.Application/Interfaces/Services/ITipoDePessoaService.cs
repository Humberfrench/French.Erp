using Dietcode.Core.DomainValidator;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface ITipoDePessoaService 
    {
        Task<ValidationResult> Gravar(TipoDePessoa tipoDePessoa);
        Task<ValidationResult> Excluir(int id);
    }
}
