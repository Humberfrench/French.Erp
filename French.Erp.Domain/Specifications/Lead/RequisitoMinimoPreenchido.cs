using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Lead
{
    public class RequisitoMinimoPreenchido : ISpecification<Entities.Lead>
    {
        public bool IsSatisfiedBy(Entities.Lead entidade)
        {
            var preenchido = 0;
            var satisfied = false;

            if(!entidade.Telefone.IsNullOrEmptyOrWhiteSpace())
            {
                preenchido++;
            }

            if (!entidade.Email.IsNullOrEmptyOrWhiteSpace())
            {
                preenchido++;
            }

            satisfied = preenchido > 0;

            return satisfied;
        }
    }
}
