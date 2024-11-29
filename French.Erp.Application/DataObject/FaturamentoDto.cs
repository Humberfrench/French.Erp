using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class FaturamentoDto 
    {
        public int FaturamentoId { get; set; }
        public int ClienteId { get; set; }
        public short Ano { get; set; }
        public byte Mes { get; set; }
        public decimal Valor { get; set; }

        public virtual ClienteDto Cliente { get; set; }
    }
}