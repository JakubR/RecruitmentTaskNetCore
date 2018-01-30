using System.Collections.Generic;
using System.Linq;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Test.TestData
{
    public class ProductsTestData : TestData<Product>
    {
        public override List<Product> GetSampleData(ICurrentDateTime currentDateTime)
        {
            var sampleCategories = new CategoryTestData().GetSampleData(currentDateTime);
            return new List<Product>()
            {
                new Product()
                {
                    IsAvailable = false,
                    Code = "Test product 1",
                    DeliveryDate = currentDateTime.Now(),
                    Categries = sampleCategories[0].Products.Take(3).ToList(),
                    ProductTypeId = 1,
                    UnitId = 1
                },
                new Product()
                {
                    IsAvailable = false,
                    Code = "Test product 2",
                    DeliveryDate = currentDateTime.Now(),
                    Categries = sampleCategories[1].Products.Take(2).ToList(),
                    ProductTypeId = 1,
                    UnitId = 1
                },
                new Product()
                {
                    IsAvailable = false,
                    Code = "Test product 3",
                    DeliveryDate = currentDateTime.Now(),
                    Categries = sampleCategories[2].Products.Take(1).ToList(),
                    ProductTypeId = 1,
                    UnitId = 2
                },
                new Product()
                {
                    IsAvailable = true,
                    Code = "Available test product 4 with one category",
                    DeliveryDate = currentDateTime.Now(),
                    Categries = sampleCategories[3].Products.Take(1).ToList(),
                    ProductTypeId = 2,
                    UnitId = 2
                },
                new Product()
                {
                    IsAvailable = true,
                    Code = "Available test product 5 with two categories",
                    DeliveryDate = currentDateTime.Now(),
                    Categries = sampleCategories[4].Products.Take(2).ToList(),
                    ProductTypeId = 2,
                    UnitId = 1
                }                
            };
        }
    }
}