using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.Interface;

namespace French.Erp.ViewModel.ViewModel
{
    public partial class TipoDeClienteViewModel : IViewModel
    {
        public TipoDeClienteViewModel()
        {
            Cliente = new HashSet<ClienteViewModel>();
        }

        public byte TipoDeClienteId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteViewModel> Cliente { get; set; }
    }
}
