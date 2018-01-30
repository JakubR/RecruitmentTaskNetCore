using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SIENN.DbAccess.Repositories
{
    public class WriteOnlyRepository<T> : GenericRepository<T> , IWriteOnlyRepository<T> where T : class
    {
        public WriteOnlyRepository(SiennDbContext context) : base(context)
        {
        }

        public T InsertData(T entity)
        {
            var insertedEntity = _context.Add(entity);
            _context.SaveChanges();
            return insertedEntity.Entity;
        }

        public ICollection<T> UpdateData(Expression<Func<T, bool>> predicate, Action<T> updateAction, params Expression<Func<T, object>>[] includeProperties)
        {
            var changedItems = new List<T>();
            IQueryable<T> dbQuery = base.InternalGetData(predicate, includeProperties);
            var entitesToUpdate = dbQuery.Where(predicate);
            var isContextChanged = false;
            foreach (var entity in entitesToUpdate)
            {
                updateAction(entity);

                var entryToTrack = _context.Entry<T>(entity);
                entryToTrack.State = EntityState.Modified;
                changedItems.Add(entryToTrack.Entity);

                isContextChanged = true;
            }

            if (isContextChanged)
            {
                _context.SaveChanges();
            }
            return changedItems;
        }

        public ICollection<T> DeleteData(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _context.Set<T>();
            var itemsToRemove = dbSet.Where(predicate);
            dbSet.RemoveRange(itemsToRemove);
            _context.SaveChanges();
            return itemsToRemove.ToList();
        }
    }
}