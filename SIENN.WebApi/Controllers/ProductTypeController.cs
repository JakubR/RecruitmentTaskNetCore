using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Domain;
using SIENN.Services.Common;
using SIENN.WebApi.Controllers.ProductTypeViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductTypeController : Controller
    {
        private readonly ICrudService<ProductType> _productTypeService;
        private readonly IMapper _mapper;

        public ProductTypeController(ICrudService<ProductType> productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }
        /// <summary>
        /// Returns ProductType for specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var productType = _productTypeService.Get(id);
                var productTypeViewModel = _mapper.Map<ProductTypeViewModel>(productType);
                return Ok(productTypeViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows  to update existing ProductType
        /// </summary>
        /// <param name="productTypeUpdateModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProductTypeUpdateModel productTypeUpdateModel)
        {
            try
            {
                var productType = _mapper.Map<ProductType>(productTypeUpdateModel);
                var updated = _productTypeService.Update(productType);
                var updatedViewModel = _mapper.Map<ProductTypeViewModel>(updated);
                return Ok(updatedViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to create new ProductType
        /// </summary>
        /// <param name="productTypeInputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] ProductTypeInputModel productTypeInputModel)
        {
            try
            {
                var productType = _mapper.Map<ProductType>(productTypeInputModel);
                var createdProductType = _productTypeService.Create(productType);
                var productTypeViewModel = _mapper.Map<ProductTypeViewModel>(createdProductType);
                return Ok(productTypeViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to delete ProductType 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _productTypeService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}