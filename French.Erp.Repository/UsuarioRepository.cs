using Dapper;
using Dietcode.Database.Domain;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository, IBaseRepository<Usuario, int>
    {
        public UsuarioRepository(IMyContextManager<ThisDatabase<Usuario>> contextManager) : base(contextManager)
        {

        }
        public async Task<Usuario> ObterUsuarioPorLogin(string login)
        {

            var sql = $"SELECT * From Usuario WHERE Login = '{login}' ORDER BY Nome";
            var query = (await Connection.QueryAsync<Usuario>(sql)).FirstOrDefault();

            return query;

        }


    }
}
