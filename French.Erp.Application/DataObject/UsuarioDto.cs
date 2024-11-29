using System;

namespace French.Erp.Application.DataObject
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime ValidadeSenha { get; set; }
        public bool Admin { get; set; }

    }
}
