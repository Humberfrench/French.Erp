using French.Erp.Application.ViewModel;

namespace French.Erp.Application.DataObject
{
    public class ArquivoNotaFiscalDto
    {
        public int ArquivoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public byte[] Arquivo { get; set; }

        public virtual NotaFiscalDto NotaFiscal { get; set; }

    }
}
