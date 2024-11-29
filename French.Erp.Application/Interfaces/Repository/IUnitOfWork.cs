using Dietcode.Core.DomainValidator;

namespace French.Erp.Application.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        ValidationResult SaveChanges();
    }
}
