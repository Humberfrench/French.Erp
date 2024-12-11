using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Lead
{
    public class TipoDePessoaPreenchido : ISpecification<Entities.Lead>
    {
        public bool IsSatisfiedBy(Entities.Lead entidade) => entidade.TipoDePessoaId > 0;

    }
}
