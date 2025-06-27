using Dietcode.Database.Domain;
using French.Erp.Domain.Entities;
using System.Threading.Tasks;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface INotaFiscalRepository : IBaseRepository<NotaFiscal, int>
    {
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
