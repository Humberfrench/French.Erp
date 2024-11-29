using French.Erp.Application.ViewModel;

namespace French.Erp.ViewModel.Interface
{
    public interface ITarefaItemAppService : IBaseApplication<TarefaItemViewModel>
    {
        Task<IEnumerable<TarefaItemViewModel>> ObterTodosItensDaTarefa(int clienteId);

    }
}
