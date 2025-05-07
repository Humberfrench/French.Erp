using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Banco
{
    public class NomePreenchido : ISpecification<Entities.Banco>
    {
        public bool IsSatisfiedBy(Entities.Banco entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();

    }
}
