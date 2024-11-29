using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.Interface;

namespace French.Erp.ViewModel.ViewModel
{
    public partial class TipoDeClienteDto 
    {
        public TipoDeClienteDto()
        {
            Cliente = new HashSet<ClienteDto>();
        }

        public byte TipoDeClienteId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ClienteDto> Cliente { get; set; }
    }
}
