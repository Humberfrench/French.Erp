using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<IEnumerable<Cidade>> ObterCidades(int uf);
    }
}
