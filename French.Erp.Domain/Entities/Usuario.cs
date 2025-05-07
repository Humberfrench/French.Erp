using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using French.Erp.Domain.Validations.Usuarios;

namespace French.Erp.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public Usuario()
        {
            validationResult = new Validation.ValidationResult();
            isValid = null;
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
        #region Dados de Validação

        [MaxLength(50), NotMapped]
        public string SenhaText { get; set; }
        public virtual Validation.ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid.HasValue)
            {
                var validationDados = Validar(this);
                if (!validationDados.Valid)
                {
                    validationDados.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
                return validationResult.Valid;
            }
            return isValid.Value;

        }

        public virtual Validation.ValidationResult Validar(Usuario entity)
        {
            var entidadeNomeValidate = new UsuarioEstaConsistente();
            var validationResultEntidade = entidadeNomeValidate.Validar(entity);
            isValid = validationResultEntidade.Valid;
            if (!validationResultEntidade.Valid)
            {
                validationResultEntidade.Erros.ToList().ForEach(e => validationResult.Add(e));
            }

            return validationResult;
        }

        #endregion

    }
}
