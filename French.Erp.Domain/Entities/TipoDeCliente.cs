using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TipoDeCliente")]
    public partial class TipoDeCliente
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public TipoDeCliente()
        {
            Clientes = new List<Cliente>();
            validationResult = new Validation.ValidationResult();
            isValid = null;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte TipoDeClienteId { get; set; }
        [Column, MaxLength(50)]
        public string Descricao { get; set; }

        [JsonIgnore, InverseProperty("TipoDeCliente")]
        public virtual IList<Cliente> Clientes { get; set; }

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

        public virtual Validation.ValidationResult Validar(TipoDeCliente entity)
        {
            var entidadeNomeValidate = new TipoDeClienteEstaConsistente();
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