using French.Erp.Application.Interfaces.Repository;
using French.Erp.Repository.Context;
using French.Erp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data;

namespace French.Erp.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        protected readonly FrenchContext Context;
        private readonly IContextManager contextManager;

        public BaseRepository(IContextManager contextManager)
        {
            this.contextManager = contextManager;
            this.Context = contextManager.GetContext();
            this.DbSet = Context.Set<TEntity>();
        }

        //for dapper
        public IDbConnection Connection => new SqlConnection(contextManager.GetConnectionString);

        public async virtual Task<bool> Adicionar(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            await DbSet.AddAsync(obj);
            entry.State = EntityState.Added;

            return true;
        }

        public async virtual Task<bool> Atualizar(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            await Task.Run(() => DbSet.Attach(obj));
            entry.State = EntityState.Modified;
            return true;
        }

        public async virtual Task<bool> Remover(TEntity obj)
        {
            var entry = this.Context.Entry(obj);
            await Task.Run(() => DbSet.Remove(obj));
            //DbSet.Remove(obj);
            entry.State = EntityState.Deleted;

            return true;
        }

        public async virtual Task<TEntity> ObterPorId(int id)
        {
            var resultado = await this.DbSet.FindAsync(id);
            return resultado;
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await Task.Run(() => this.DbSet.ToList());
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodosPaginado(int pagina, int registros)
        {
            return await Task.Run(() => this.DbSet.Take(pagina).Skip(registros));
        }

        public async virtual Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => this.DbSet.Where(predicate));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
