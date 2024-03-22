using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Application.services.Brands;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandServices _brandServices;
        public BrandController(IBrandServices   brandServices) { 
        _brandServices = brandServices;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandServices.GetAllBrand();
            if(brands==null||brands.Count==0)
            {
                return NoContent();
            }
             return Ok(brands);
        }
        [HttpGet("GetAllBrandsWithCategories")]
        public async Task<IActionResult> GetAllBrandsWithCategories()
        {
            var brands = await _brandServices.GetAllBrandWithCategory();
            if (brands == null || brands.Count == 0)
            {
                return NoContent();
            }
            return Ok(brands);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            GetBrandDTO brand = await _brandServices.GetBrandByID(id);
            if (brand == null)
            {
                return NoContent();
            }
            return Ok(brand);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostAsync([FromBody] CreateBrandDTO brand)
        {
            if (ModelState.IsValid)
            {
                await _brandServices.CreateBrand(brand);
                return Ok(brand);

            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateBrandDTO brand)
        {
            if (ModelState.IsValid)
            {
                await _brandServices.UpdateBrand(brand);
                return Ok(brand);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if(await _brandServices.DeleteBrand(id)==null)
                return BadRequest();
            return Ok();
        }
    }
}
