﻿using Dapper;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository, IBaseRepository<Usuario>
    {
        public UsuarioRepository(IContextManager contextManager) : base(contextManager)
        {

        }
        public async Task<Usuario> ObterUsuarioPorLogin(string login)
        {
            var sql = $"SELECT * From Usuario WHERE Login = '{login}' ORDER BY Nome";
            var query = await Task.Run(() => Connection.Query<Usuario>(sql).FirstOrDefault());

            return query;

        }


    }
}
