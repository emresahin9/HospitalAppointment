using Core.Entity.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IQueryable<T>> include = null);
        T Get(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>> include = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(Expression<Func<T, bool>> filter);
    }
}
