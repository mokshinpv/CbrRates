using System;
using System.Data.Entity;
using System.Linq;

namespace CbrRates.Framework.DataAccess
{
    public class EntityFrameworkRepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntityKey<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private DbContext _context;
        protected readonly Lazy<DbSet<TEntity>> DbSet;

        public EntityFrameworkRepositoryBase(DbContext context)
            : this()
        {
            _context = context;
        }
        public EntityFrameworkRepositoryBase()
        {
            DbSet = new Lazy<DbSet<TEntity>>(() => _context.Set<TEntity>());
        }

        public void Insert(TEntity entity)
        {
            DbSet.Value.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = _context.Entry(entity).State == EntityState.Added ? EntityState.Added : EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public TEntity[] SelectAll()
        {
            return DbSet.Value.ToArray();
        }
        
        public TEntity Find(TKey key)
        {
            return DbSet.Value.Find(key);
        }

        public IQueryable<TEntity> Query()
        {
            return DbSet.Value;
        }

        public void SetUnitOfWork(IUnitOfWork unitOfWork)
        {
            _context = ((EntityFrameworkUnitOfWork)unitOfWork).DbContext;
        }
    }
}
