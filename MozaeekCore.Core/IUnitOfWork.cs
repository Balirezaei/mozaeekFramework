using System.Threading.Tasks;

namespace MozaeekCore.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}