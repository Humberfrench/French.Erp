using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;
using System.Text.Json.Serialization;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TipoDeCliente")]
    public partial class TipoDeCliente : EntityBase<TipoDeCliente>
    {
        private readonly Validation.ValidationResult validationResult;

        public TipoDeCliente()
        {
            Clientes = new List<Cliente>();
            validationResult = new Validation.ValidationResult();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte TipoDeClienteId { get; set; }

        [Column, MaxLength(50)]
        public string Descricao { get; set; }

        [JsonIgnore, InverseProperty("TipoDeCliente")]
        public virtual IList<Cliente> Clientes { get; set; }

        #region Dados de Validação

        protected override Validation.Validator<TipoDeCliente> ObterValidador()
        {
            return new TipoDeClienteEstaConsistente();
        }

        #endregion
    }
}

