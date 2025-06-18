using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Tarefa")]
    public partial class Tarefa : EntityBase<Tarefa>
    {

        public Tarefa()
        {
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
        protected override Validation.Validator<Tarefa> ObterValidador()
        {
            return new TarefaEstaConsistente();
        }

        #endregion

    }
}