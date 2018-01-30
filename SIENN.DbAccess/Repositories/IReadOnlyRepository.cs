using System;
using System.Linq;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        T GetFirst(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetDataQueryable(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}