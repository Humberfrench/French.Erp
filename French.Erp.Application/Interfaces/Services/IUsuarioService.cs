using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<ValidationResult<Usuario>> Gravar(Usuario usuario);
        Task<ValidationResult<Usuario>> Login(string login, string senha);
        Task<ValidationResult<Usuario>> Excluir(int id);
        Task<ValidationResult<Usuario>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova);
    }
}
