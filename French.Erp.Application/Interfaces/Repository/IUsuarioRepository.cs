using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IUsuarioRepository: IBaseRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioPorLogin(string login);
    }
}
