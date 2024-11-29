using French.Erp.Application.ViewModel;

namespace French.Erp.ViewModel.Interface
{
    public interface ITarefaAppService : IBaseApplication<TarefaViewModel>
    {
        Task<IEnumerable<TarefaViewModel>> ObterTodosDoCliente(int clienteId);
        Task<string> ObterNumeroDaNota(int tarefaId);
    }
}
