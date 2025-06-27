using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IFeriadoRepository : IBaseRepository<Feriado, int>
    {
        Task<List<Feriado>> ObterFeriadosMes(int mes);
    }
}
