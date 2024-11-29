using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Tributos
{
    public class PercentualPreenchido : ISpecification<Entities.Tributo>
    {
        public bool IsSatisfiedBy(Entities.Tributo entidade) => entidade.Percentual > 0;

    }
}
