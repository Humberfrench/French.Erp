using Dietcode.Core.DomainValidator;
using French.Erp.Application.DataObject;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IUsuarioService 
    {
        Task<ValidationResult<UsuarioDto>> Gravar(Usuario usuario);
        Task<ValidationResult<UsuarioDto>> Login(string login, string senha);
        Task<ValidationResult<bool>> Excluir(int id);
        Task<ValidationResult<UsuarioDto>> AlterarSenha(int usuarioId, string senhaAnterior, string senhaNova);
    }
}
