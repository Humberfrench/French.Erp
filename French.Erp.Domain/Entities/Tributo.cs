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
    public partial class Tributo
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public Tributo()
        {
            validationResult = new Validation.ValidationResult();
            isValid = null;
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

        public virtual Validation.ValidationResult Validar(Tributo entity)
        {
            var entidadeNomeValidate = new TributoEstaConsistente();
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