using Dietcode.Core.DomainValidator.Interfaces;
using Dietcode.Core.Lib;

namespace French.Erp.Domain.Specifications.Clientes
{
    public class DocumentoPreenchido : ISpecification<Entities.Cliente>
    {
        public bool IsSatisfiedBy(Entities.Cliente entidade) => !entidade.Documento.IsNullOrEmptyOrWhiteSpace();

    }
}
