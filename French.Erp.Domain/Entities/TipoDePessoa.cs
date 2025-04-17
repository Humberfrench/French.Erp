using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TipoDePessoa")]
    public partial class TipoDePessoa
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public TipoDePessoa()
        {
            Cliente = new List<Cliente>();
            validationResult = new Validation.ValidationResult();
            isValid = null;

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte TipoDePessoaId { get; set; }

        [Column, MaxLength(50)]
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual IList<Cliente> Cliente { get; set; }

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

        public virtual Validation.ValidationResult Validar(TipoDePessoa entity)
        {
            var entidadeValidate = new TipoDePessoaEstaConsistente();
            var validationResultEntidade = entidadeValidate.Validar(entity);
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