using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorLogin(string login);
    }
}
