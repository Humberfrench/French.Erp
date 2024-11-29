using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface IServicoService : IBaseService<Servico>
    {
        Task<ValidationResult> Gravar(Servico tipoDePessoa);
        Task<ValidationResult> Excluir(int id);
    }
}
