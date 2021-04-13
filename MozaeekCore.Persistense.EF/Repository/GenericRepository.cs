using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MozaeekCore.Domain;

namespace MozaeekCore.Persistense.EF.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasicInfo
    {
        private readonly CoreDomainContext _context;

        public GenericRepository(CoreDomainContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public Task<T> Find(long id)
        {
            return _context.Set<T>().Where(m=>m.Id==id).AsNoTracking().FirstOrDefaultAsync();
        }
        //ToDo: Remove this and read from read model
        public IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }
    }
}