using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Clientes
{
    public class RazaoSocialPreenchido : ISpecification<Entities.Cliente>
    {
        public bool IsSatisfiedBy(Entities.Cliente entidade) => !entidade.RazaoSocial.IsNullOrEmptyOrWhiteSpace();

    }
}
