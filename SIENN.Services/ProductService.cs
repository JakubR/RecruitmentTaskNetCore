using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using SIENN.Services.Common;
using SIENN.Services.Products;

namespace SIENN.Services
{
    public class ProductService : IProductService
    {
        private const int MinimumCountOfCategoriesForAvailableProductsMethod = 2;
        private readonly IReadOnlyRepository<Product> _productRoRepository;
        private readonly IWriteOnlyRepository<Product> _productWoRepository;
        private readonly ICurrentDateTime _currentDateTime;

        public ProductService(
            IReadOnlyRepository<Product> productRoRepository,
            IWriteOnlyRepository<Product> productWoRepository,
            ICurrentDateTime currentDateTime)
        {
            _productRoRepository = productRoRepository;
            _productWoRepository = productWoRepository;
            _currentDateTime = currentDateTime;
        }

        public List<Product> GetNotAvailableProductsWhichDeliveryIsPlanedInCurrentMonth()
        {
            //TODO implement pagination (not specified in task)
            return _productRoRepository.GetDataQueryable(
                    x => x.IsAvailable == false && CheckProductDeliveryDateIsInCurrentMonth(x.DeliveryDate.Value),
                    product => product.Categries,
                    product => product.ProductType,
                    product => product.Unit)
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _productRoRepository.GetFirst(x => x.Id == id, 
                product => product.Categries, 
                product => product.ProductType, 
                product => product.Unit);
        }

        public Product UpdateProduct(Product product)
        {
            var result = _productWoRepository.UpdateData(x => x.Id == product.Id,
                 entity =>
                 {
                     entity.IsAvailable = product.IsAvailable;
                     entity.Price = product.Price;
                     entity.Code = product.Code;
                     entity.DeliveryDate = product.DeliveryDate;
                     entity.Description = product.Description;
                     entity.ProductTypeId = product.ProductTypeId;
                     entity.UnitId = product.UnitId;
                     entity.Categries = GetUpdatedCategories(entity, product);
                 }, x => x.Categries).First();
            return result;
        }

        public Product CreateProduct(Product product)
        {
            var result = _productWoRepository.InsertData(product);
            return result;
        }

        public IList<Product> GetAvailableProducts(int skip, int take)
        {
            var result = _productRoRepository
                .GetDataQueryable(x => x.IsAvailable, 
                                  product => product.Categries, 
                                  product => product.ProductType,
                                  product => product.Unit)
                    .OrderBy(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .ToList();
            return result;
        }

        public IList<Product> GetFilteredProducts(int productTypeId = 0, int unitId = 0, int categoryId = 0, int skip = 0, int take = 50)
        {
            var result = _productRoRepository.GetDataQueryable(
                x => (productTypeId == 0 ? true : x.ProductTypeId == productTypeId) &&
                     (unitId == 0 ? true : x.UnitId == unitId) &&
                     (categoryId == 0 ? true : x.Categries.Any(y => y.CategoryId == categoryId)),
                product => product.Categries,
                product => product.ProductType,
                product => product.Unit)
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(take)
            .ToList();

            return result;
        }

        private ICollection<ProductCategory> GetUpdatedCategories(Product savedEntity, Product inputEntity)
        {
            AddNewCategories(savedEntity, inputEntity);
            RemoveNotUsedCategories(savedEntity, inputEntity);

            return savedEntity.Categries;
        }

        private static void RemoveNotUsedCategories(Product savedEntity, Product inputEntity)
        {
            foreach (var savedEntityCategry in savedEntity.Categries)
            {
                if (inputEntity.Categries.Any(x => x.CategoryId == savedEntityCategry.CategoryId) == false)
                {
                    savedEntity.Categries.Remove(savedEntityCategry);
                }
            }
        }

        private static void AddNewCategories(Product savedEntity, Product inputEntity)
        {
            foreach (var category in inputEntity.Categries)
            {
                if (savedEntity.Categries.Any(x => x.CategoryId == category.CategoryId))
                {
                    continue;
                }
                savedEntity.Categries.Add(category);
            }
        }

        private bool CheckProductDeliveryDateIsInCurrentMonth(DateTime deliveryDate)
        {
            var now = _currentDateTime.Now();
            return now.Month == deliveryDate.Month &&
                   now.Year == deliveryDate.Year;
        }

        public List<Product> GetAvailableProductsWithMoreThanOneCategory()
        {
            //TODO implement pagination (not specified in task)
            return _productRoRepository.GetDataQueryable(
                    x => x.IsAvailable && x.Categries.Count >= MinimumCountOfCategoriesForAvailableProductsMethod,
                    product => product.Categries,
                    product => product.Unit,
                    product => product.ProductType)
                .ToList();
        }
    }
}