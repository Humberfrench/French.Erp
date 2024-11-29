using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Tributos
{
    public class FaixaInicialPreenchido : ISpecification<Entities.Tributo>
    {
        public bool IsSatisfiedBy(Entities.Tributo entidade) => entidade.FaixaInicial >= 0;

    }
}
