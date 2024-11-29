using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Clientes
{
    public class TipoDePessoaPreenchido : ISpecification<Entities.Cliente>
    {
        public bool IsSatisfiedBy(Entities.Cliente entidade) => entidade.TipoDePessoaId > 0;

    }
}
