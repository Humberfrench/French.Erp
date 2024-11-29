using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Tarefas
{
    public class NomePreenchido : ISpecification<Tarefa>
    {
        public bool IsSatisfiedBy(Entities.Tarefa entidade) => !entidade.Nome.IsNullOrEmptyOrWhiteSpace();

    }
}
