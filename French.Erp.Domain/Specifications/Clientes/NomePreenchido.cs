using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Clientes
{
    public class NomePreenchido : ISpecification<Entities.Cliente>
    {
        public bool IsSatisfiedBy(Entities.Cliente entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();

    }
}
