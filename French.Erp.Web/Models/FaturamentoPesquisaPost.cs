namespace French.Erp.Web.Models
{
    public class FaturamentoPesquisaPost
    {
        public int ClienteId { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool Faturado { get; set; }
    }
}
