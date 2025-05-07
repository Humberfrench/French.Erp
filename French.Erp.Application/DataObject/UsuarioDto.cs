using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace French.Erp.Application.DataObject
{
    public class UsuarioDto
    {
        [Required, Range(1,10000)]
        public int UsuarioId { get; set; }

        [Required, MaxLength(20)]
        public string Login { get; set; }

        [Required, MaxLength(50)]
        public string Nome { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(15)]
        public string Celular { get; set; }

        [MaxLength(50)]
        public string Documento { get; set; }

        [MaxLength(50)]
        public string SenhaText { get; set; }

        [Required, Range(0, 5)]
        public int TentativasInvalidas { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public DateTime? DataLogin { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public DateTime ValidadeSenha { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
        public bool Ativo { get; set; }

    }
}
