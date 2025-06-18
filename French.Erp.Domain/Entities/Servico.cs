using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

#nullable disable

namespace French.Erp.Domain.Entities
{
    [Table("Servico")]
    public partial class Servico : EntityBase<Servico>
    {

        public Servico()
        {
            TarefaItems = new List<TarefaItem>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicoId { get; set; }

        [Column, Required, MaxLength(30)]
        public string Nome { get; set; }

        [Column, Required, MaxLength(75)]
        public string Descricao { get; set; }

        [InverseProperty("Servico")]
        public virtual IList<TarefaItem> TarefaItems { get; set; }

        #region Dados de Validação
        protected override Validation.Validator<Servico> ObterValidador()
        {
            return new ServicoEstaConsistente();
        }
        #endregion
    }

}
