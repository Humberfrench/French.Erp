using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Servicos
{
    public class DescricaoPreenchida : ISpecification<Entities.Servico>
    {
        public bool IsSatisfiedBy(Entities.Servico entidade) => !entidade.Descricao.IsNullOrEmptyOrWhiteSpace();

    }
}
