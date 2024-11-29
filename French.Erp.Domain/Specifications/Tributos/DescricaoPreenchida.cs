using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Tributos
{
    public class DescricaoPreenchida : ISpecification<Entities.Tributo>
    {
        public bool IsSatisfiedBy(Entities.Tributo entidade) => !entidade.Descricao.IsNullOrEmptyOrWhiteSpace();

    }
}
