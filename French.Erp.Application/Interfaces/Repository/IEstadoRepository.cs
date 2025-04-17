using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dietcode.Database.Domain;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IEstadoRepository : IBaseRepository<Estado>
    {
        new Task<IEnumerable<Estado>> ObterTodos();
    }
}
