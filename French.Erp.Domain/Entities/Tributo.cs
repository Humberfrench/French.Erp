using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Tributo")]
    public partial class Tributo : EntityBase<Tributo>
    {
        public Tributo()
        {
            TributoNotaFiscals = new List<TributoNotaFiscal>();
        }

        /// <summary>
        /// Codigo
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TributoId { get; set; }

        /// <summary>
        /// Descricao
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        /// <summary>
        /// Valor
        /// </summary>
        [Column(TypeName = "numeric(18, 2)")]
        public decimal Percentual { get; set; }

        [Column]
        public bool RetemNaNota { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal FaixaInicial { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal FaixaFinal { get; set; }

        [Column(TypeName = "numeric(18, 2)")]
        public decimal ValorDeducao { get; set; }

        [InverseProperty("Tributo")]
        public virtual IList<TributoNotaFiscal> TributoNotaFiscals { get; set; } = new List<TributoNotaFiscal>();


        #region Dados de Validação
        protected override Validation.Validator<Tributo> ObterValidador()
        {
            return new TributoEstaConsistente();
        }

        #endregion

    }
}