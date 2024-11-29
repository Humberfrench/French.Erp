using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Servicos
{
    public class NomePreenchido : ISpecification<Servico>
    {
        public bool IsSatisfiedBy(Entities.Servico entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();

    }
}
