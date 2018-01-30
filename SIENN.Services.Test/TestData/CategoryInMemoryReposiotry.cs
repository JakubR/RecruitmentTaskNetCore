using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Test.TestData
{
    public class CategoryInMemoryReposiotry : IReadOnlyRepository<Category>
    {
        private List<Category> _categires;

        public CategoryInMemoryReposiotry(ICurrentDateTime currentDateTime)
        {
            _categires = new CategoryTestData().GetSampleData(currentDateTime);
        }

        public Category GetFirst(Expression<Func<Category, bool>> predicate, params Expression<Func<Category, object>>[] includeProperties)
        {
            return _categires.AsQueryable().Where(predicate).First();
        }

        public IQueryable<Category> GetDataQueryable(Expression<Func<Category, bool>> predicate, params Expression<Func<Category, object>>[] includeProperties)
        {
            return _categires.AsQueryable().Where(predicate);
        }       
    }
}