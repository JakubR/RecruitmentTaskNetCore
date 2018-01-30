using System;
using System.Diagnostics;
using System.Linq;
using Castle.Core.Logging;
using Moq;
using NUnit.Framework;
using SIENN.DbAccess.Repositories;
using SIENN.Domain;
using SIENN.Services.Common;
using SIENN.Services.Test.TestData;

namespace SIENN.Services.Test
{
    public class ProductServiceTest
    {
        private ProductService _productService;
        private IReadOnlyRepository<Product> _productRepository;
        private ICurrentDateTime _currentDateTime;
        private IWriteOnlyRepository<Product> _writeOnlyProductRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            var currentDateTimeMock = new Mock<ICurrentDateTime>();
            currentDateTimeMock.Setup(time => time.Now()).Returns(new DateTime(2017, 01, 28));
            _currentDateTime = currentDateTimeMock.Object;
            _writeOnlyProductRepository = new Mock<IWriteOnlyRepository<Product>>().Object;
            _productRepository = new ProductInMemoryRepository(_currentDateTime);
            _productService = new ProductService(_productRepository, _writeOnlyProductRepository, _currentDateTime);
        }

        //1. Niedostępne produkty, których dostawa jest przewidywana w bieżącym miesiącu
        [Test]
        public void GetNotAvailableProductsWhichDeliveryIsPlanedInCurrentMonth_ShouldReturnUnavailableProductsWhichDevliveryIsPlanedInCurrentMonth()
        {
            var result = _productService.GetNotAvailableProductsWhichDeliveryIsPlanedInCurrentMonth();

            Assert.True(
                result.All(x => x.IsAvailable == false &&
                x.DeliveryDate.Value.Month >= _currentDateTime.Now().Month &&
                x.DeliveryDate.Value.Month < _currentDateTime.Now().AddMonths(1).Month),
                $"All recived products should have delivery date in current month and IsAvailable property set to false");
        }

        //2. Dostępne produkty, które są przypisane do więcej niż jednej kategorii
        [Test]
        public void
            GetAvailableProductsWithMoreThanOneCategory_ShouldReturnAvailableProductsWithMoreThanOneCategory()
        {
            var result = _productService.GetAvailableProductsWithMoreThanOneCategory();

            Assert.True(result.All(x => x.Categries.Count >= 2 && x.IsAvailable), $"All products returned from method 'GetAvailableProductsWithMoreThanOneCategory' should have at least 2 categories and propery IsAvailable == true");
        }

        //Dodaj metodę do API, który pozwoli przefiltrować produkty wg typu, kategorii oraz jednostki (można użyć wszystkich filtrów)
        [Test]
        public void GetProductsForProductTypeIdEqualsOne_ShouldReturnOnlyProductsWithProductTypeEqualsOne()
        {
            var result = _productService.GetFilteredProducts(1);

            Assert.True(result.All(x=>x.ProductTypeId == 1) , $"Expected only elements with product type =1 but recived {string.Join(",", result.Where(x=>x.ProductTypeId !=1).Select(x=>x.ProductType.Code))}");
            Assert.True(result.Count > 0, $"Expected more than 0 results");
        }

        [Test]
        public void GetProductsForProductUnitIdEqualsOne_ShouldReturnOnlyProductsWithUnitIdEqualsOne()
        {
            var result = _productService.GetFilteredProducts(0,1);

            Assert.True(result.Count > 0, $"Expected more than 0 results");
            Assert.True(result.All(x => x.UnitId == 1), $"Expected only elements with unit id = 1 but recived {string.Join(",", result.Where(x => x.UnitId != 1).Select(x => x.ProductType.Code))}");
        }

        [Test]
        public void GetProductsForProductWhichBelongsToCategoryOne_ShouldReturnOnlyProductsWithAtLeastCategoryOne()
        {
            var result = _productService.GetFilteredProducts(0, 0, 1);

            Assert.True(result.Count > 0, $"Expected more than 0 results");
            Assert.True(result.All(x => x.UnitId == 1), $"Expected only elements which contains elements with category = 1 but recived elements without category id equals 1");
        }
    }
}