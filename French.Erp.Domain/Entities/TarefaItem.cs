using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TarefaItem")]
    public partial class TarefaItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaItemId { get; set; }

        [Column]
        public int TarefaId { get; set; }

        [Column]
        public byte Ordem { get; set; }

        [Required, Column, MaxLength(50)]
        public string Descricao { get; set; }

        [Column]
        public int ServicoId { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime? Data { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal HorasOrcadas { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal HorasGastas { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal ValorHora { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal ValorItem { get; set; }

        [ForeignKey("ServicoId")]
        [InverseProperty("TarefaItems")]
        public virtual Servico Servico { get; set; }

        [ForeignKey("TarefaId")]
        [InverseProperty("TarefaItems")]
        public virtual Tarefa Tarefa { get; set; }
    }
}