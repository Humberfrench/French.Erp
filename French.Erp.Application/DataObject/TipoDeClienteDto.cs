using French.Erp.Application.ViewModel;
using System.Collections.Generic;

namespace French.Erp.Application.DataObject
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
