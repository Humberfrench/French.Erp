namespace French.Erp.ViewModel.ViewModel
{
    public class ClienteDadosDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeCompleto => $"{Nome} - {RazaoSocial}";
    }
}