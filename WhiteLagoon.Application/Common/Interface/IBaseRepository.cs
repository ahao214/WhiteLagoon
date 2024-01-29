using System.Linq.Expressions;

namespace WhiteLagoon.Application.Common.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        bool Any(Expression<Func<T, bool>> filter);
        void Remove(T entity);
    }
}
