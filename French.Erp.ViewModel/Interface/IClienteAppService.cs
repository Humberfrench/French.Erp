using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.ViewModel;

namespace French.Erp.ViewModel.Interface
{
    public interface IClienteAppService : IBaseApplication<ClienteViewModel>
    {
        Task<IEnumerable<ClienteDadosViewModel>> ObterTodosParaCombo();
    }
}
