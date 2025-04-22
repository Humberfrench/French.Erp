using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using French.Erp.Domain.Validations.StatusNotaFiscals;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("StatusNotaFiscal")]
    public partial class StatusNotaFiscal
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public StatusNotaFiscal()
        {
            NotaFiscal = new List<NotaFiscal>();
            validationResult = new Validation.ValidationResult();
            isValid = null;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte StatusNotaFiscalId { get; set; }

        [Required]
        [MaxLength(50)]

        public string Descricao { get; set; }

        [InverseProperty("StatusNotaFiscal")]
        public virtual IList<NotaFiscal> NotaFiscal { get; set; } 

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

        public virtual Validation.ValidationResult Validar(StatusNotaFiscal entity)
        {
            var entidadeNomeValidate = new StatusNotaFiscalEstaConsistente();
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