using Dietcode.Core.DomainValidator.Interfaces;
using French.Erp.Domain.Entities;

namespace French.Erp.Domain.Specifications.Tarefas
{
    public class ClientePreenchido : ISpecification<Tarefa>
    {
        public bool IsSatisfiedBy(Tarefa entidade) => entidade.ClienteId > 0;

    }
}
