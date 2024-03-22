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
        [HttpGet("cat/{categoryId:int}")]
        public async Task<IActionResult> getByCategory(int  categoryId)
        {
            var products = await _productServices.GetByCategory(categoryId);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("brand/{brandId:int}")]
        public async Task<IActionResult> GetByBrand(int brandId)
        {
            var products = await _productServices.GetByBrand(brandId);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("{categoryId:int}/{brandId:int}")]
        public async Task<IActionResult> GetByBrandAndCategory(int categoryId, int brandId)
        {
            var products = await _productServices.GetByBrandAndCategory(brandId,categoryId);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("search/{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var products = await _productServices.SearchName(name);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("pages")]
        public async Task<IActionResult> GetAllPagination(int numOfProductPerPage,int pageNumber)
        {
            var products = await _productServices.GetAllPagination(numOfProductPerPage, pageNumber);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var product = await _productServices.GetProductByID(id);
            if (product == null )
            {
                return NoContent();
            }
            return Ok(product);
        }
        [HttpGet("catCount/{catId}")]
        public async Task<IActionResult> GetCountByCategory(int catId)=> Ok(await _productServices.GetCountByCategory(catId));
        [HttpGet("catCount/{brandId}")]
        public async Task<IActionResult> GetCountByBrand(int brandId)=>Ok(await _productServices.GetCountByBrand(brandId));
    }
}
