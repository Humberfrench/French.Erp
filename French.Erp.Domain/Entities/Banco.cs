using French.Erp.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
namespace French.Erp.Domain.Entities
{
    [Table("Bancos")]
    public partial class Banco : EntityBase<Banco>
    {
        private readonly Validation.ValidationResult validationResult;

        public Banco()
        {
            validationResult = new Validation.ValidationResult();
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BancoId { get; set; }

        [Required, StringLength(10)]
        public string Codigo { get; set; }

        [Required, StringLength(150)]
        public string Nome { get; set; }

        [Required, StringLength(50)]
        public string Apelido { get; set; }
        [Required]
        public bool Status { get; set; }

        #region Dados de Validação
        protected override Validation.Validator<Banco> ObterValidador()
        {
            return new BancoEstaConsistente();
        }

        #endregion
    }
}
