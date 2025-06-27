using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("TipoDePessoa")]
    public partial class TipoDePessoa : EntityBase<TipoDePessoa>
    {
        public TipoDePessoa()
        {
            Clientes = new List<Cliente>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte TipoDePessoaId { get; set; }

        [Column, MaxLength(50)]
        public string Descricao { get; set; }

        [JsonIgnore, InverseProperty("TipoDePessoa")]
        public virtual IList<Cliente> Clientes { get; set; }

        #region Dados de Validação
        protected override Validation.Validator<TipoDePessoa> ObterValidador()
        {
            return new TipoDePessoaEstaConsistente();
        }
        #endregion

    }
}