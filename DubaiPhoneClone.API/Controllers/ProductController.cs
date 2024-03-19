using DubaiPhoneClone.Application.services.product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubaiPhoneClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProuductService _productServices;

        public ProductController(IProuductService productImageServices)
        {
            _productServices= productImageServices;
        }
        [HttpGet]
        public async Task<IActionResult> getALL()
        {
            var products = await _productServices.GetAllProduct();
            if (products == null||products.Count==0) {
                return NoContent();   
            }
            return Ok(products);
        }
    }
}
