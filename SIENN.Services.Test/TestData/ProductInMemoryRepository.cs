using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Test.TestData
{
    public class ProductInMemoryRepository : IReadOnlyRepository<Product>
    {
        private List<Product> _products;

        public ProductInMemoryRepository(ICurrentDateTime currentDateTime)
        {
            _products = new ProductsTestData().GetSampleData(currentDateTime);
        }

        public Product GetFirst(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includeProperties)
        {
            return _products.AsQueryable().Where(predicate).First();
        }

        public IQueryable<Product> GetDataQueryable(Expression<Func<Product, bool>> predicate, params Expression<Func<Product, object>>[] includeProperties)
        {
            return _products.AsQueryable().Where(predicate);
        }
    }
}