using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Banco
{
    public class ApelidoPreenchida : ISpecification<Entities.Banco>
    {
        public bool IsSatisfiedBy(Entities.Banco entidade) => !entidade.Apelido.IsNullOrEmptyOrWhiteSpace();

    }
}
