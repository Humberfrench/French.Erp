﻿using Dietcode.Database.Domain;
using Dapper;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;

namespace French.Erp.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository, IBaseRepository<Usuario>
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
