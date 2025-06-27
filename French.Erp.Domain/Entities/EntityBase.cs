using Dietcode.Core.DomainValidator;
using French.Erp.Domain.Validations;

namespace French.Erp.Domain.Entities
{
    public abstract class EntityBase<T> where T : class
    {
        private readonly ValidationResult validationResult = new ValidationResult();

        public virtual ValidationResult ValidationResult => validationResult;


        /// <summary>
        /// Valida a entidade usando a especificação que deve ser fornecida pela classe derivada.
        /// </summary>
        /// <returns>Retorna o ValidationResult com os erros, se existirem.</returns>
        public virtual ValidationResult Validar(T entidade)
        {
            var validator = ObterValidador();
            var result = validator?.Validar(entidade);

            if (result != null && !result.Valid)
            {
                foreach (var erro in result.Erros)
                    validationResult.Add(erro);
            }

            return validationResult;
        }

        /// <summary>
        /// Indica se a entidade é válida.
        /// </summary>
        /// <returns>True se válida, false caso contrário.</returns>
        public virtual bool IsValid()
        {
            Validar(this as T);
            return validationResult.Valid;
        }

        /// <summary>
        /// Deve ser implementado na classe derivada para fornecer o validador correspondente.
        /// </summary>
        /// <returns>Validador da entidade.</returns>
        protected abstract Validator<T> ObterValidador();
    }
}
