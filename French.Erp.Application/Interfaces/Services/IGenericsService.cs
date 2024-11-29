using System.Collections.Generic;
using System.Threading.Tasks;
using French.Erp.Domain.Entities;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IGenericsService
    {
        Task<IEnumerable<Estado>> ObterEstados();
        Task<IEnumerable<Cidade>> ObterCidades(int uf);
    }
}
