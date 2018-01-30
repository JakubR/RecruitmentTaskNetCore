using System;
using System.Collections.Generic;
using SIENN.WebApi.Controllers.CategoryViewModels;
using SIENN.WebApi.Controllers.ProductTypeViewModels;
using SIENN.WebApi.Controllers.UnitViewModels;

namespace SIENN.WebApi.Controllers.ProductViewModels
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Product code maximum length 128 chars, can not be null
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Product description maximum length 500 chars
        /// </summary>
        public string Description { get; set; }
        public decimal Price { get; set; }       
        public string IsAvailable { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ProductTypeUpdateModel ProductType { get; set; }
        public List<CategoryViewModel> Categries { get; set; }
        public UnitUpdateModel Unit { get; set; }

    }
}