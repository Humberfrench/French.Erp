using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using French.Erp.Domain.Validations.TipoDeClientes;

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
        public string Descricao { get; set; }

        [JsonIgnore]
        [InverseProperty("TipoDeCliente")]
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