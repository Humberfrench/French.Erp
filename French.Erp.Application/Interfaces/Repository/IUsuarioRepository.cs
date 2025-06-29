using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, int>
    {
        Task<Usuario> ObterUsuarioPorLogin(string login);
    }
}
