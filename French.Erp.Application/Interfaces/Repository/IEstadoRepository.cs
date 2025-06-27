using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IEstadoRepository : IBaseRepository<Estado, int>
    {
        new Task<IEnumerable<Estado>> ObterTodos();
    }
}
