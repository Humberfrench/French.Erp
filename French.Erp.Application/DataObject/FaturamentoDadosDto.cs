#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class FaturamentoDadosDto
    {
        public int FaturamentoId { get; set; }
        public string Cliente { get; set; }
        public int ClienteId { get; set; }
        public short Ano { get; set; }
        public byte Mes { get; set; }
        public decimal Valor { get; set; }
        public bool Faturado { get; set; }
        public int UsuarioId { get; set; }
    }
}