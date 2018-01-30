using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Domain;
using SIENN.Services.Products;
using SIENN.WebApi.Controllers.ProductViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/product")]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return product for specifed Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int Id)
        {
            try
            {
                var product = _productService.GetProduct(Id);
                var productViewModel = _mapper.Map<ProductViewModel>(product);
                return Ok(productViewModel);
            }
            catch (Exception e)
            {
                //TODO Log error
                Console.WriteLine(e);
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Allows user to update existing product
        /// </summary>
        /// <param name="productInputModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProductUpdateModel productInputModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productInputModel);
                var updatedProduct = _productService.UpdateProduct(product);
                var productViewModel = _mapper.Map<ProductViewModel>(updatedProduct);
                return Ok(productViewModel);
            }
            catch (Exception e)
            {
                //TODO Log error
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows user to create new product
        /// </summary>
        /// <param name="productInputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] ProductInputModel productInputModel)
        {
            try
            {
                var product = _mapper.Map<Product>(productInputModel);
                var createdProduct = _productService.CreateProduct(product);
                var productViewModel = _mapper.Map<ProductViewModel>(createdProduct);
                return Ok(productViewModel);
            }
            catch (Exception e)
            {
                //TODO Log error
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}