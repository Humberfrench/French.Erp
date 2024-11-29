using French.Erp.Application.ViewModel;

namespace French.Erp.ViewModel.Interface
{
    public interface IGenericsAppService
    {
        Task<IEnumerable<EstadoViewModel>> ObterEstados();
        Task<IEnumerable<CidadeViewModel>> ObterCidades(int uf);

    }
}
