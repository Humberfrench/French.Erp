using French.Erp.Application.ViewModel;
using French.Erp.ViewModel.Interface;

namespace French.Erp.ViewModel.ViewModel
{
    public class ArquivoNotaFiscalViewModel : IViewModel
    {
        public int ArquivoNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public byte[] Arquivo { get; set; }

        public virtual NotaFiscalViewModel NotaFiscal { get; set; }

    }
}
