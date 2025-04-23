using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using French.Erp.Domain.Validations.Tarefas;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Tarefa")]
    public partial class Tarefa
    {
        private readonly Validation.ValidationResult validationResult;
        private bool isValid;

        public Tarefa()
        {
            validationResult = new Validation.ValidationResult();
            isValid = false;
            ComposicaoNotaFiscals = new List<ComposicaoNotaFiscal>();
            TarefaItems = new List<TarefaItem>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int TarefaId { get; set; }
        
        [Column, Required]
        public int ClienteId { get; set; }

        [Column]
        public int? NotaFiscalId { get; set; }

        [Required, Column, MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(250), Column]
        public string Observacao { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorOrcado { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? TotalHoras { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorHora { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorBruto { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorDesconto { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ValorCobrado { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Comissao { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? DataInicio { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? DataFim { get; set; }

        [Column, Required]
        public int UsuarioId { get; set; }

        [ForeignKey("ClienteId")]
        [InverseProperty("Tarefas")]
        public virtual Cliente Cliente { get; set; }

        [InverseProperty("Tarefa")]
        public virtual IList<ComposicaoNotaFiscal> ComposicaoNotaFiscals { get; set; } 

        [InverseProperty("Tarefa")]
        public virtual IList<TarefaItem> TarefaItems { get; set; } 


        #region Dados de Validação
        public virtual Validation.ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid)
            {
                var validationDados = Validar(this);
                if (!validationDados.Valid)
                {
                    validationDados.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
                return validationResult.Valid;
            }
            return isValid;

        }

        public virtual Validation.ValidationResult Validar(Tarefa entity)
        {
            var entidadeNomeValidate = new TarefaEstaConsistente();
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