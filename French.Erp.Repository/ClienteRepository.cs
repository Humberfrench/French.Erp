using French.Erp.Application.Interfaces.Repository;
using French.Erp.Domain.Entities;
using French.Erp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository, IBaseRepository<Cliente>
    {
        public ClienteRepository(IContextManager contextManager) : base(contextManager)
        {

        }

        public new async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await Task.Run(() => this.DbSet.Include(c => c.TipoDeCliente)
                                                  .Include(c => c.TipoDePessoa)
                                                  .Include(c => c.Tarefa)
                                                  .Include(c => c.NotaFiscal)
                                                  .Include(c => c.Faturamento)
                                                  .Include(c => c.Cidade)
                                                  .ToList());
        }

        public new async Task<Cliente> ObterPorId(int id)
        {

            return await Task.Run(() => this.DbSet.Include(c => c.TipoDeCliente)
                                                  .Include(c => c.TipoDePessoa)
                                                  .Include(c => c.Tarefa)
                                                  .Include(c => c.NotaFiscal)
                                                  .Include(c => c.Faturamento)
                                                  .Include(c => c.Cidade)
                                                  .FirstOrDefaultAsync(c => c.ClienteId == id));
        }

    }
}
