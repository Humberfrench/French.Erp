#nullable disable

namespace French.Erp.Application.DataObject
{
    public partial class CidadeDto
    {
        public CidadeDto()
        {
        }

        /// <summary>
        /// Codigo
        /// </summary>
        public int CidadeId { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }
        public int EstadoId { get; set; }
    }
}