using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace French.Erp.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async virtual Task<bool> Adicionar(TEntity obj)
        {
            return await this.repository.Adicionar(obj);
        }

        public async virtual Task<bool> Atualizar(TEntity obj)
        {
            return await this.repository.Atualizar(obj);
        }

        public async virtual Task<bool> Remover(TEntity obj)
        {
            return await this.repository.Remover(obj);
        }

        public async virtual Task<TEntity> ObterPorId(int id)
        {
            return await this.repository.ObterPorId(id);
        }

        public async virtual Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await this.repository.ObterTodos();
        }

        public void Dispose()
        {
            this.repository.Dispose();
        }

        public async virtual Task<IEnumerable<TEntity>> Pesquisar(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.repository.Pesquisar(predicate);
        }
    }
}
