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
            List<Brand> brands = await _brandServices.GetAllBrand();
            if(brands==null||brands.Count==0)
            {
                return NoContent();
            }
             return Ok(brands);
        }
    }
}
