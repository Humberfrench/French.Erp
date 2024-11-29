using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.TipoDePessoas
{
    public class DescricaoPreenchida : ISpecification<TipoDePessoa>
    {
        public bool IsSatisfiedBy(Entities.TipoDePessoa entidade) => !entidade.Descricao.IsNullOrEmptyOrWhiteSpace();

    }
}
