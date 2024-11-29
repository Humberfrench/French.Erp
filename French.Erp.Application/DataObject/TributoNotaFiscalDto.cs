using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class TributoNotaFiscalDto 
    {
        public int TributoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int TributoId { get; set; }
        public decimal Total { get; set; }

        public virtual NotaFiscalDto NotaFiscal { get; set; }
        public virtual TributoDto Tributo { get; set; }
    }
}