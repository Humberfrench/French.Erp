namespace French.Erp.Application.DataObject
{
    public class ClienteDadosDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeCompleto => $"{Nome} - {RazaoSocial}";
    }
}
