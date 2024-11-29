using System.Threading.Tasks;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface INotaFiscalRepository
    {
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
