using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added; ;
                context.SaveChanges();
            }
        }

        public void Delete(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var entity = context.Set<TEntity>().FirstOrDefault(filter);
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            using (TContext context = new TContext())
            {
                if (include != null) return include(context.Set<TEntity>()).FirstOrDefault(filter);
                else return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
        {
            using (TContext context = new TContext())
            {
                if (filter != null && include != null) return include(context.Set<TEntity>()).Where(filter).ToList();
                else if (filter == null && include != null) return include(context.Set<TEntity>()).ToList();
                else if (filter != null && include == null) return context.Set<TEntity>().Where(filter).ToList();
                else return context.Set<TEntity>().ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
