using System.Collections.Generic;
using System.Linq;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Units
{
    public class CategoryService : ICrudService<Category>
    {
        private readonly IReadOnlyRepository<Category> _categoryRoRepository;
        private readonly IWriteOnlyRepository<Category> _categoryWoRepository;

        public CategoryService(IReadOnlyRepository<Category> categoryRoRepository, IWriteOnlyRepository<Category> categoryWoRepository)
        {
            _categoryRoRepository = categoryRoRepository;
            _categoryWoRepository = categoryWoRepository;
        }

        public List<CategorySummary> GetTop3Categories()
        {
            var result = Enumerable.Select(_categoryRoRepository.GetDataQueryable(
                    x => x.Products.Any(y => y.Product.IsAvailable)), 
                    availableProduct => new CategorySummary()
                         {
                             Code = availableProduct.Code,
                             Description = availableProduct.Description,
                             AveragePrice = availableProduct.Products.Where(x => x.Product.IsAvailable).Average(product => product.Product.Price),
                             AvailableProductsCount = availableProduct.Products.Count(x => x.Product.IsAvailable)
                         })
                .OrderByDescending(x => x.AveragePrice)
                .Take(3);
            return result.ToList();
        }

        public Category Create(Category entity)
        {
            return _categoryWoRepository.InsertData(entity);
        }

        public void Delete(int id)
        {
            _categoryWoRepository.DeleteData(x => x.Id == id);
        }

        public Category Get(int id)
        {
            return _categoryRoRepository.GetDataQueryable(x=>x.Id == id, category => category.Products).First();
        }

        public Category Update(Category entity)
        {
            return _categoryWoRepository.UpdateData(x => x.Id == entity.Id,
                x =>
                {
                    x.Code = entity.Code;
                    x.Description = entity.Description;
                }
            ).First();
        }
    }
}