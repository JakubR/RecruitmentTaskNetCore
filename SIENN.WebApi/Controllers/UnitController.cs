using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SIENN.Domain;
using SIENN.Services.Common;
using SIENN.WebApi.Controllers.UnitViewModels;

namespace SIENN.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        private readonly ICrudService<Unit> _unitService;
        private readonly IMapper _mapper;

        public UnitController(ICrudService<Unit> unitService, IMapper mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns Unit for specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                var unit = _unitService.Get(id);
                var unitViewModel = _mapper.Map<UnitViewModel>(unit);
                return Ok(unitViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to update existing Unit
        /// </summary>
        /// <param name="unitUpdateModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] UnitUpdateModel unitUpdateModel)
        {
            try
            {
                var unit = _mapper.Map<Unit>(unitUpdateModel);
                var updatedUnit = _unitService.Update(unit);
                var unitViewModel = _mapper.Map<UnitViewModel>(updatedUnit);
                return Ok(unitViewModel);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to create new Unit
        /// </summary>
        /// <param name="unitInputModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] UnitInputModel unitInputModel)
        {
            try
            {
                var newUnit = _mapper.Map<Unit>(unitInputModel);
                var createdUnit = _unitService.Update(newUnit);
                var unitViewModel = _mapper.Map<UnitViewModel>(createdUnit);
                return Ok(unitViewModel);                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        /// <summary>
        /// Allows to delete unit 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitService.Delete(id);
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