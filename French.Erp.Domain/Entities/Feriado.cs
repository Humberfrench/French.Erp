using French.Erp.Domain.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Validation = Dietcode.Core.DomainValidator;

#nullable enable
namespace French.Erp.Domain.Entities
{
    [Table("Feriado")]
    public partial class Feriado : EntityBase<Feriado>
    {
        public Feriado()
        {
            Nome = string.Empty;
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
        protected override Validation.Validator<Feriado> ObterValidador()
        {
            return new FeriadoEstaConsistente();
        }
        #endregion
    }

    }
