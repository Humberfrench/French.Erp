﻿using Dietcode.Database.Domain;
using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using Dietcode.Database.Orm;
using Dietcode.Database.Orm.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository, IBaseRepository<Tarefa>
    {
        public TarefaRepository(IMyContextManager<ThisDatabase<Tarefa>> context) : base(context)
        {

        }

        public new async Task<IEnumerable<Tarefa>> ObterTodos()
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItems)
                                                  .ToList());
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosDoCliente(int clienteId)
        {
            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItems)
                                                  .Where(c => c.ClienteId == clienteId)
                                                  .ToList());
        }

        public new async Task<Tarefa> ObterPorId(int id)
        {

            return await Task.Run(() => this.DbSet.Include(t => t.Cliente)
                                                  .Include(t => t.TarefaItems)
                                                  .FirstOrDefaultAsync(c => c.TarefaId == id));
        }

    }
}
