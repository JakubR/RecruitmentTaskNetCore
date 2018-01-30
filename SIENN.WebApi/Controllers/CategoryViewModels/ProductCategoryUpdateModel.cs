using System;
using SIENN.WebApi.Controllers.ProductViewModels;

namespace SIENN.WebApi.Controllers.CategoryViewModels
{
    public class ProductCategoryUpdateModel
    {
        public string ProductId { get; set; }
        public ProductUpdateModel Product { get; set; }
        public String CategoryId { get; set; }
        public CategoryUpdateModel Category { get; set; }
    }
}