using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var category = await _categoryServices.GetAllCategory();
            if (category == null || category.Count == 0)
            {
                return NoContent();
            }
            return Ok(category);
        }

        [HttpGet("GetAllCategoriesWithBrands")]
        public async Task<IActionResult> GetAllBrandsWithCategories()
        {
            var categories = await _categoryServices.GetAllCategoryWithBrand();
            if (categories == null || categories.Count == 0)
            {
                return NoContent();
            }
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            GetCategoryDTO category = await _categoryServices.GetCategoryByID(id);
            if (category == null)
            {
                return NoContent();
            }
            return Ok(category);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.CreateCategory(category);
                return Ok(category);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.UpdateCategory(category);
                return Ok(category);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _categoryServices.DeleteCategory(id)== null)
                return BadRequest();
            return Ok();
        }
    }
}
