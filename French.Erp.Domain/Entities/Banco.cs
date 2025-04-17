using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Validation = Dietcode.Core.DomainValidator;
namespace French.Erp.Domain.Entities
{
    [Table("Banco")]
    public partial class Banco
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BancoId { get; set; }

        public string Codigo { get; set; }

        public string Nome { get; set; }

        public bool Status { get; set; }
    }
}
