using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Domain;
using SIENN.Services.Common;
using SIENN.Services.Units;
using SIENN.WebApi.Controllers.CategoryViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly ICrudService<Category> _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICrudService<Category> categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns Category for specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.Get(id);
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
                return Ok(categoryViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to update existing Category
        /// </summary>
        /// <param name="categoryUpdateModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryUpdateModel categoryUpdateModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryUpdateModel);
                var updatedCategory = _categoryService.Update(category);
                var categoryViewModel = _mapper.Map<CategoryViewModel>(updatedCategory);
                return Ok(categoryViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to create new Category
        /// </summary>
        /// <param name="categoryInputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CategoryInputModel categoryInputModel)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryInputModel);
                var createdCategory = _categoryService.Create(category);
                var categoryViewModel = _mapper.Map<CategoryViewModel>(createdCategory);
                return Ok(categoryViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to delete category 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
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