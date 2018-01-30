using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;
using SIENN.Services.Test.TestData;
using SIENN.Services.Units;

namespace SIENN.Services.Test
{
    public class CategoryServiceTest
    {
        private CategoryService _categoryService;
        private CategoryInMemoryReposiotry _categoryInMemoryReposiotry;
        private IWriteOnlyRepository<Category> _writeOnlyCategoryRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            _categoryInMemoryReposiotry = new CategoryInMemoryReposiotry(new CurrentDateTime());
            _writeOnlyCategoryRepository = new Mock<IWriteOnlyRepository<Category>>().Object;
            _categoryService = new CategoryService(_categoryInMemoryReposiotry, _writeOnlyCategoryRepository);
        }

        //Top 3 kategorie wraz z informacją o liczbie przypisanych, dostępnych produktów oraz średnią ceną produktów w kategorii (top 3 powinno pokazywać kategorie, których średnia cen produktów jest największa)
        [Test]
        public void GetTop3Categories_ShouldReturn3CategoriesInWhichAveragePriceOfProductsIsBigest()
        {
            List<CategorySummary> allCategoriesSummary = _categoryInMemoryReposiotry.GetDataQueryable(x => x.Products.Any(product => product.Product.IsAvailable))
                .Select(category => new CategorySummary()
                {
                    AveragePrice = (category.Products.Where(x => x.Product.IsAvailable).Average(x => x.Product.Price))
                })
                .OrderByDescending(x => x.AveragePrice)
                .ToList();
            var largestAveragePriceCategorySummary = allCategoriesSummary.First();

            var top3Categories = _categoryService.GetTop3Categories();

            Assert.True(top3Categories[0].AveragePrice == largestAveragePriceCategorySummary.AveragePrice, $"First category from Top3 should be equal {largestAveragePriceCategorySummary.AveragePrice}, but was {top3Categories[0].AveragePrice }");
            Assert.True(top3Categories[1].AveragePrice <= allCategoriesSummary[0].AveragePrice, $"Second category from Top3 should be smaller than first one, but was bigger");
            Assert.True(top3Categories[2].AveragePrice <= allCategoriesSummary[1].AveragePrice, $"Third category from Top3 should be smaller than second one, but was bigger");
        }

        [Test]
        public void GetTop3Categories_ShouldReturn3Categories()
        {
            var top3Categories = _categoryService.GetTop3Categories();
            Assert.True(top3Categories.Count == 3, $"Expected top 3 categories should be 3 but was {top3Categories.Count}");
        }

    }
}