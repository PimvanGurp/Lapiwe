using Lapiwe.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lapiwe.GMS.FrontEnd.DAL
{
    public class SimpleRepository : IDisposable, ISimpleRepository
    {
        private FrontendContext _context;

        public SimpleRepository(FrontendContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> FindAll<TEntity>() where TEntity : DomainEntity
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Find<TEntity>(Guid guid) where TEntity : DomainEntity
        {
            return _context.Set<TEntity>().FirstOrDefault(entity => entity.Guid == guid);
        }

        public void Add<TEntity>(TEntity entity) where TEntity : DomainEntity
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
