namespace French.Erp.ViewModel.Interface
{
    public interface IBaseServiceApp
    {
        void BeginTransaction();
        Task Commit();

    }
}
