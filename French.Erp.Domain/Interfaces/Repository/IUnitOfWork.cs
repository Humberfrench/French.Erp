using Dietcode.Core.DomainValidator;

namespace French.Erp.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
    }
}
