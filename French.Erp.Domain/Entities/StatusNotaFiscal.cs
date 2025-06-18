using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("StatusNotaFiscal")]
    public partial class StatusNotaFiscal : EntityBase<StatusNotaFiscal>
    {

        public StatusNotaFiscal()
        {
            NotaFiscals = new List<NotaFiscal>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte StatusNotaFiscalId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [InverseProperty("StatusNotaFiscal")]
        public virtual IList<NotaFiscal> NotaFiscals { get; set; }

        #region Dados de Validação
        protected override Validation.Validator<StatusNotaFiscal> ObterValidador()
        {
            return new StatusNotaFiscalEstaConsistente();
        }


        #endregion
    }
}