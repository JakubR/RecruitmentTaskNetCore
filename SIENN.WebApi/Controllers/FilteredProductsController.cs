using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Products;
using SIENN.WebApi.Controllers.ProductViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FilteredProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public FilteredProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns products filtred by parameters
        /// </summary>
        /// <param name="productTypeId">Specify product type Id</param>
        /// <param name="unitId">Specify product unit id</param>
        /// <param name="categoryId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int productTypeId, int unitId, int categoryId, int skip, int take)
        {
            try
            {
                var filteredProducts = _productService.GetFilteredProducts(productTypeId, unitId, categoryId, skip, take);
                var filteresProductsViewModels = _mapper.Map<List<ProductViewModel>>(filteredProducts);
                return Ok(filteresProductsViewModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}