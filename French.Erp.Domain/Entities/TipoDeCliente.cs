using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations.TipoDeClientes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace French.Erp.Domain.Entities
{
    public partial class TipoDeCliente
    {
        private readonly ValidationResult validationResult;
        private bool? isValid;

        public TipoDeCliente()
        {
            Cliente = new HashSet<Cliente>();
            validationResult = new ValidationResult();
            isValid = null;
        }

        public byte TipoDeClienteId { get; set; }
        public string Descricao { get; set; }

        [JsonIgnore]
        public virtual ICollection<Cliente> Cliente { get; set; }

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

        public virtual ValidationResult Validar(TipoDeCliente entity)
        {
            var entidadeNomeValidate = new TipoDeClienteEstaConsistente();
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