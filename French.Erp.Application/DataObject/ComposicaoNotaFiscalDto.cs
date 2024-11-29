using System;
using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.ViewModel
{
    public partial class ComposicaoNotaFiscalDto 
    {
        public int ComposicaoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int TarefaId { get; set; }
        public decimal Total { get; set; }

        public virtual NotaFiscalDto NotaFiscal { get; set; }
        public virtual TarefaDto Tarefa { get; set; }
    }
}