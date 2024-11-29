using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.TipoDeClientes
{
    public class DescricaoPreenchida : ISpecification<TipoDeCliente>
    {
        public bool IsSatisfiedBy(Entities.TipoDeCliente entidade) => !entidade.Descricao.IsNullOrEmptyOrWhiteSpace();

    }
}
