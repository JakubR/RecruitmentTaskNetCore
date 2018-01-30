using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Products;
using SIENN.WebApi.Controllers.ProductTypeViewModels;
using SIENN.WebApi.Controllers.ProductViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AvailableProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public AvailableProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all available products
        /// </summary>
        /// <param name="skip">Number of records to be skiped</param>
        /// <param name="take">Number of records to be taken</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int skip, int take)
        {
            try
            {
                var availableProducts = _productService.GetAvailableProducts(skip, take);
                var availableProductViewModels = _mapper.Map<List<ProductViewModel>>(availableProducts);
                return Ok(availableProductViewModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}