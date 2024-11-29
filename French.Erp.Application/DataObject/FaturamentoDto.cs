#nullable disable

namespace French.Erp.Application.DataObject
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