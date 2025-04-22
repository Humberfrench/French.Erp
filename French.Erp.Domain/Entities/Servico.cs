using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDePessoas;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using French.Erp.Domain.Validations.Servicos;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Servico")]
    public partial class Servico
    {
        private readonly Validation.ValidationResult validationResult;
        private bool? isValid;

        public Servico()
        {
            TarefaItems = new List<TarefaItem>();
            validationResult = new Validation.ValidationResult();
            isValid = null;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicoId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(75)]
        public string Descricao { get; set; }

        [InverseProperty("Servico")]
        public virtual IList<TarefaItem> TarefaItems { get; set; } 

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

        public virtual Validation.ValidationResult Validar(Servico entity)
        {
            var entidadeNomeValidate = new ServicoEstaConsistente();
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