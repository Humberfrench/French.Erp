using French.Erp.Application.DataObject;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Services
{
    public interface IGenericsService
    {
        Task<IEnumerable<EstadoDto>> ObterEstados();
        Task<IEnumerable<CidadeDto>> ObterCidades(int uf);
        Task<IEnumerable<CidadeDto>> ObterCidades();

    }
}
