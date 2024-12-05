using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class StatusNotaFiscalDto
    {
        public StatusNotaFiscalDto()
        {
            NotaFiscal = new HashSet<NotaFiscalDto>();
        }

        public byte StatusNotaFiscalId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<NotaFiscalDto> NotaFiscal { get; set; }
    }
}