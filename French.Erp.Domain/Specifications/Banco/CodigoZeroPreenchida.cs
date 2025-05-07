using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using System;

namespace French.Erp.Domain.Specifications.Banco
{
    public class CodigoZeroPreenchida : ISpecification<Entities.Banco>
    {
        public bool IsSatisfiedBy(Entities.Banco entidade) => Convert.ToInt16(entidade.Codigo) > 0;
    }
}
