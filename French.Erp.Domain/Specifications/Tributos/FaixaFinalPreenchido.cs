using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Tributos
{
    public class FaixaFinalPreenchido : ISpecification<Entities.Tributo>
    {
        public bool IsSatisfiedBy(Entities.Tributo entidade) => entidade.FaixaFinal >= 0;

    }
}
