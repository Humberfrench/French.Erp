using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using French.Erp.Domain.Validations.Tributos;

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
            TributoNotaFiscal = new HashSet<TributoNotaFiscal>();
        }

        /// <summary>
        /// Codigo
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TributoId { get; set; }
        /// <summary>
        /// Descricao
        /// </summary>
        public string Descricao { get; set; } 
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Percentual { get; set; }
        public bool RetemNaNota { get; set; }
        public decimal FaixaInicial { get; set; }
        public decimal FaixaFinal { get; set; }
        public decimal ValorDeducao { get; set; }

        public virtual ICollection<TributoNotaFiscal> TributoNotaFiscal { get; set; }
 
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