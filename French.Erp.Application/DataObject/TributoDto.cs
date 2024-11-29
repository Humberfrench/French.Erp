using System.Collections.Generic;

#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class TributoDto
    {
        public TributoDto()
        {
            TributoNotaFiscal = new HashSet<TributoNotaFiscalDto>();
        }

        /// <summary>
        /// Codigo
        /// </summary>
        public int TributoId { get; set; }
        /// <summary>
        /// Descricao
        /// </summary>
        public string Descricao { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Percentual { get; set; }
        public bool RetemNaNota { get; set; }
        public decimal FaixaInicial { get; set; }
        public decimal FaixaFinal { get; set; }
        public decimal ValorDeducao { get; set; }

        public virtual ICollection<TributoNotaFiscalDto> TributoNotaFiscal { get; set; }
    }
}