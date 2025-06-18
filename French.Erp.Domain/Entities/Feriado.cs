using French.Erp.Domain.Validations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;

#nullable enable
namespace French.Erp.Domain.Entities
{
    [Table("Feriado")]
    public partial class Feriado
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public Feriado()
        {
            Nome = string.Empty;
            validationResult = new Validation.ValidationResult();
            isValid = null;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeriadoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public byte Dia { get; set; }

        public byte Mes { get; set; }

        public short Ano { get; set; }

        public int CidadeId { get; set; }

        public int EstadoId { get; set; }

        public Cidade? Cidade { get; set; }

        public Estado? Estado { get; set; }


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

        public virtual Validation.ValidationResult Validar(Feriado entity)
        {
            var entidadeNomeValidate = new FeriadoEstaConsistente();
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