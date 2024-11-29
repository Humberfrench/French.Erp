using Dietcode.Core.DomainValidator.Interfaces;

namespace French.Erp.Domain.Specifications.Clientes
{
    public class TipoDeClientePreenchido : ISpecification<Entities.Cliente>
    {
        public bool IsSatisfiedBy(Entities.Cliente entidade) => entidade.TipoDeClienteId > 0;

    }
}
