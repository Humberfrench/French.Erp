using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TarefaItem")]
    public partial class TarefaItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaItemId { get; set; }
        public int TarefaId { get; set; }
        public byte Ordem { get; set; }
        public string Descricao { get; set; }
        public int ServicoId { get; set; }
        public DateTime? Data { get; set; }
        public decimal HorasOrcadas { get; set; }
        public decimal HorasGastas { get; set; }
        public decimal ValorHora { get; set; }
        public decimal ValorItem { get; set; }

        public virtual Servico Servico { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}