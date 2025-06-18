using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using System;
using System.Linq.Expressions;

namespace French.Erp.Domain.Specifications
{
    public class PropriedadeEmailValido<T> : ISpecification<T>
    {
        private readonly Func<T, string> _propAccessor;
        public PropriedadeEmailValido(Expression<Func<T, string>> propriedade)
        {
            _propAccessor = propriedade.Compile();
        }
        public bool IsSatisfiedBy(T entidade)
        {
            var email = _propAccessor(entidade);
            return !string.IsNullOrWhiteSpace(email) && email.IsValidEmail();
        }
    }
}
