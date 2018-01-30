using System;
using System.Collections.Generic;
using SIENN.WebApi.Controllers.CategoryViewModels;
using SIENN.WebApi.Controllers.ProductTypeViewModels;
using SIENN.WebApi.Controllers.UnitViewModels;

namespace SIENN.WebApi.Controllers.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ProductTypeViewModel ProductType { get; set; }
        public List<CategoryViewModel> Categries { get; set; }
        public UnitViewModel Unit { get; set; }
    }
}