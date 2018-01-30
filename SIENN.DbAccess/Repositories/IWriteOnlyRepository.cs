using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SIENN.DbAccess.Repositories
{
    public interface IWriteOnlyRepository<T>
    {
        T InsertData(T entity);
        ICollection<T> UpdateData(Expression<Func<T, bool>> predicate, Action<T> updateAction, params Expression<Func<T, object>>[] includeProperties);
        ICollection<T> DeleteData(Expression<Func<T, bool>> predicate);
    }
}