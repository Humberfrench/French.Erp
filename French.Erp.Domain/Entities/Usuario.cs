using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

namespace French.Erp.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : EntityBase<Usuario>
    {
        public Usuario()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required, Column, MaxLength(20)]
        public string Login { get; set; }

        [Required, Column, MaxLength(50)]
        public string Nome { get; set; }

        [Required, Column, MaxLength(100)]
        public string Email { get; set; }

        [Required, Column, MaxLength(15)]
        public string Celular { get; set; }

        [Column, MaxLength(50)]
        public string Documento { get; set; }

        [Required, Column, MaxLength(264)]
        public byte[] Senha { get; set; }

        [Column]
        public int TentativasInvalidas { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataLogin { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DataAtualizacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ValidadeSenha { get; set; }

        [Column]
        public bool Admin { get; set; }

        [Column]
        public bool Ativo { get; set; }


        [MaxLength(50), NotMapped]
        public string SenhaText { get; set; }
        #region Dados de Validação
        protected override Validation.Validator<Usuario> ObterValidador()
        {
            return new UsuarioEstaConsistente();
        }
        #endregion

    }
}
