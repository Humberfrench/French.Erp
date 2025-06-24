using System;
using System.Collections.Generic;

namespace French.Erp.Application.DataObject
{
    public partial class TarefaDto
    {
        public TarefaDto()
        {
            ComposicaoNotaFiscal = new HashSet<ComposicaoNotaFiscalDto>();
            TarefaItem = new HashSet<TarefaItemDto>();
        }

        public int TarefaId { get; set; }
        public int ClienteId { get; set; }
        public int? NotaFiscalId { get; set; }
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorOrcado { get; set; }
        public decimal? TotalHoras { get; set; }
        public decimal? ValorDesconto { get; set; }
        public decimal? ValorBruto { get; set; }
        public decimal? ValorHora { get; set; }
        public decimal? ValorCobrado { get; set; }
        public decimal? Comissao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool GerarItems{ get; set; }

        public virtual ClienteDto Cliente { get; set; }
        public virtual ICollection<ComposicaoNotaFiscalDto> ComposicaoNotaFiscal { get; set; }
        public virtual ICollection<TarefaItemDto> TarefaItem { get; set; }
    }
}