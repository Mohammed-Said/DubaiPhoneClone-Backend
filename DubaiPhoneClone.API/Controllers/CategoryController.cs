using DubaiPhoneClone.Application.services.Categorys;
using DubaiPhoneClone.Models;
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
        public async Task<IActionResult> GetAllCategories()
        {
            List<Category> category = await _categoryServices.GetAllCategory();
            if (category == null || category.Count == 0)
            {
                return NoContent();
            }
            return Ok(category);
        }
    }
}
