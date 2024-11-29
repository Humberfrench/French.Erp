using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.Servicos;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class Servico
    {
        private readonly ValidationResult validationResult;
        private bool? isValid;

        public Servico()
        {
            TarefaItem = new HashSet<TarefaItem>();
            validationResult = new ValidationResult();
            isValid = null;
        }

        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<TarefaItem> TarefaItem { get; set; }

        #region Dados de Validação
        public virtual ValidationResult ValidationResult => validationResult;

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

        public virtual ValidationResult Validar(Servico entity)
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