using System;

namespace French.Erp.Application.DataObject
{
    public class LeadDto
    {
        public LeadDto()
        {
            Descricao = string.Empty;
            Empresa = string.Empty;
            Contato = string.Empty;
            Documento = string.Empty;
            Telefone = string.Empty;
            Email = string.Empty;
            Efetivada = false;

        }
        public int LeadId { get; set; }

        public string Descricao { get; set; }

        public string Empresa { get; set; }

        public string Contato { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public int UsuarioId { get; set; }

        public bool Efetivada { get; set; }

        public byte TipoDePessoaId { get; set; }

        public byte TipoDeClienteId { get; set; }
    }
}
