using MozaeekCore.Core;
using System.Threading.Tasks;

namespace MozaeekCore.Persistense.EF
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private readonly CoreDomainContext _context;

        public EFUnitOfWork(CoreDomainContext context)
        {
            _context = context;
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}