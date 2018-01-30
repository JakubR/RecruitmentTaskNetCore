using System.Collections.Generic;
using SIENN.Domain;
using SIENN.Services.Common;

namespace SIENN.Services.Test.TestData
{
    public class CategoryTestData : TestData<Category>
    {
        public override List<Category> GetSampleData(ICurrentDateTime currentDateTime)
        {
            var product1 = new Product()
            {
                Code = "Product 1",
                Price = 1,
                IsAvailable = true,
                ProductTypeId = 1,
                UnitId = 1
            };
            var product2 = new Product()
            {
                Code = "Product 2",
                Price = 2,
                IsAvailable = true,
                ProductTypeId = 1,
                UnitId = 1
            };
            var product3 = new Product()
            {
                Code = "Product 3",
                Price = 3,
                IsAvailable = true,
                ProductTypeId = 1,
                UnitId = 1
            };
            var product4 = new Product()
            {
                Code = "Product 4",
                Price = 1,
                IsAvailable = false,
                ProductTypeId = 2,
                UnitId = 2
            };
            var product5 = new Product()
            {
                Code = "Product 5",
                Price = 2,
                IsAvailable = false,
                ProductTypeId = 2,
                UnitId = 2
            };
            var product6 = new Product()
            {
                Code = "Product 6",
                Price = 3,
                IsAvailable = false,
                ProductTypeId = 3,
                UnitId = 3
            };

            return new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Code = "First category",
                    Products =
                        new List<ProductCategory>()
                        {
                            new ProductCategory() {Product = product1, CategoryId = 1},
                            new ProductCategory() {Product = product2, CategoryId = 1},
                            new ProductCategory() {Product = product3, CategoryId = 1},
                            new ProductCategory() {Product = product6, CategoryId = 1}
                        }
                },
                new Category()
                {
                    Id = 2,
                    Code = "Second category",
                    Products =
                        new List<ProductCategory>()
                        {
                            new ProductCategory() {Product = product1, CategoryId = 2},
                            new ProductCategory() {Product = product6, CategoryId = 2}
                        }                                          
                },                                                 
                new Category()
                {
                    Id = 3,
                    Code = "Third category",
                    Products =
                        new List<ProductCategory>()
                        {
                            new ProductCategory() {Product = product1, CategoryId = 3},
                            new ProductCategory() {Product = product5, CategoryId = 3}
                        }                                         
                },                                                
                new Category()
                {
                    Id = 4,
                    Code = "Fourth category",
                    Products =
                        new List<ProductCategory>()
                        {
                            new ProductCategory() {Product = product2},
                            new ProductCategory() {Product = product3}
                        }
                },
                new Category()
                {
                    Id = 5,
                    Code = "Fifth category",
                    Products =
                        new List<ProductCategory>()
                        {
                            new ProductCategory() {Product = product4},
                            new ProductCategory() {Product = product5},
                            new ProductCategory() {Product = product6}
                        }
                }
            };
        }        
    }
}