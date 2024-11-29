using French.Erp.Repository.Context;

namespace French.Erp.Repository.Interfaces
{
    public interface IContextManager
    {
        FrenchContext GetContext();
        string GetConnectionString { get; }
    }
}
