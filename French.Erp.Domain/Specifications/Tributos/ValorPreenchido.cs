using Dietcode.Core.DomainValidator.Interfaces;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Tributos
{
    public class ValorPreenchido : ISpecification<Tributo>
    {
        public bool IsSatisfiedBy(Tributo entidade) => entidade.ValorDeducao >= 0;

    }
}
