using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dietcode.Database.Domain;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        new Task<IEnumerable<Cliente>> ObterTodos();
        new Task<Cliente> ObterPorId(int id);
    }
}
