using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.StatusNotaFiscals
{
    public class DescricaoPreenchida : ISpecification<StatusNotaFiscal>
    {
        public bool IsSatisfiedBy(StatusNotaFiscal entidade) => !entidade.Descricao.IsNullOrEmptyOrWhiteSpace();

    }
}
