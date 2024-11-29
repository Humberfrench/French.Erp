using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Services
{
    public interface IGenericsService
    {
        Task<IEnumerable<Estado>> ObterEstados();
        Task<IEnumerable<Cidade>> ObterCidades(int uf);
    }
}
