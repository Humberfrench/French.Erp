namespace French.Erp.Application.DataObject
{
    public class LeadEntryDto
    {
        public LeadEntryDto()
        {
            RazaoSocial = string.Empty;
            RazaoSocial = string.Empty;
            CadastroMunicipal = string.Empty;
            Endereco = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
            Bairro = string.Empty;
            Cep = string.Empty;
            EstadoId = 0;
            CidadeId = 0;
            LeadId = 0;
        }
        public int LeadId { get; set; }

        public string RazaoSocial { get; set; }

        public string InscricaoEstadual { get; set; }

        public string CadastroMunicipal { get; set; }

        public string Endereco { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public int UsuarioId { get; set; }

        public int? EstadoId { get; set; }

        public int? CidadeId { get; set; }

    }
}
