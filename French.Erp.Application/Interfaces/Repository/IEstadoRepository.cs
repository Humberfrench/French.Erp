using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<Estado>> ObterTodos();
    }
}
