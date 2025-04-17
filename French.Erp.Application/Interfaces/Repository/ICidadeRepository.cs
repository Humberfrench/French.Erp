using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<IEnumerable<Cidade>> ObterCidades(int uf);
    }
}
