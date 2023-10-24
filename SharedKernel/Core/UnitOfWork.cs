
namespace SharedKernel.Core
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
