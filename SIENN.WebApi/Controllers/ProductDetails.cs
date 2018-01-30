using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Services.Products;
using SIENN.WebApi.Controllers.ProductDetailsViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductDetailsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductDetailsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns detailed information about product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                var productDetailsViewModel = _mapper.Map<ProductDetailsViewModel>(product);
                return Ok(productDetailsViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}