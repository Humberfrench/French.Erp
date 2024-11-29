using Dietcode.Core.DomainValidator;
using System.Runtime.InteropServices;

namespace French.Erp.ViewModel.Interface
{
    public interface IBaseApplication<V> where V : IViewModel, new()
    {
        //Generic Methods
        Task<ValidationResult<V>> Gravar(V servico);
        Task<ValidationResult<V>> Excluir(int id);
        Task<V> ObterPorId(int id);
        Task<IEnumerable<V>> ObterTodos();

    }
}
