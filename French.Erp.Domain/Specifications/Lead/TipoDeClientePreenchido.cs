using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Lead
{
    public class TipoDeClientePreenchido : ISpecification<Entities.Lead>
    {
        public bool IsSatisfiedBy(Entities.Lead entidade) => entidade.TipoDeClienteId > 0;

    }
}
