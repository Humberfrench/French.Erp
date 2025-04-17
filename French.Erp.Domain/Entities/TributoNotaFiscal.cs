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
    [Table("TributoNotaFiscal")]
    public partial class TributoNotaFiscal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TributoNotaFiscalId { get; set; }

        public int NotaFiscalId { get; set; }

        public int TributoId { get; set; }

        public decimal Total { get; set; }

        public virtual NotaFiscal NotaFiscal { get; set; }
        public virtual Tributo Tributo { get; set; }
    }
}