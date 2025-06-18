using French.Erp.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
namespace French.Erp.Domain.Entities
{
    [Table("Bancos")]
    public partial class Banco
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public Banco()
        {
            validationResult = new Validation.ValidationResult();
            isValid = null;
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
        public virtual Validation.ValidationResult ValidationResult => validationResult;

        public virtual bool IsValid()
        {
            if (!isValid.HasValue)
            {
                var validationDados = Validar();
                if (!validationDados.Valid)
                {
                    validationDados.Erros.ToList().ForEach(e => validationResult.Add(e));
                }
                return validationResult.Valid;
            }
            return isValid.Value;

        }

        public virtual Validation.ValidationResult Validar()
        {
            var entidadeNomeValidate = new BancoEstaConsistente();
            var validationResultEntidade = entidadeNomeValidate.Validar(this);
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
