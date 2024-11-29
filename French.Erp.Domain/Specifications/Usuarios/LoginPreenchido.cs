using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Usuarios
{
    public class LoginPreenchido : ISpecification<Usuario>
    {
        public bool IsSatisfiedBy(Usuario entidade) => !entidade.Login.IsNullOrEmptyOrWhiteSpace();

    }
}
