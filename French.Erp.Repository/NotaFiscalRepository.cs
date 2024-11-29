using Dapper;
using French.Erp.Domain.Entities;
using French.Erp.Domain.Interfaces.Repository;
using French.Erp.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace French.Erp.Repository
{
    public class NotaFiscalRepository : BaseRepository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(IContextManager contextManager) : base(contextManager)
        {


        }
        public async Task<string> ObterNumeroDaNota(int tarefaId)
        {
            var sql = $@"SELECT ISNULL(n.Numero, '0') 
                             FROM NotaFiscal  n
                             JOIN Tarefa t
                             ON n.NotaFiscalId = t.NotaFiscalId
                             AND t.TarefaId = {tarefaId}";
            var query = await Task.Run(() => Connection.Query<string>(sql));

            return query.FirstOrDefault();
        }
    }
}
