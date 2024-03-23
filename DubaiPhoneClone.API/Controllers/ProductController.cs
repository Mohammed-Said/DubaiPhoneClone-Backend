using DubaiPhone.DTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Application.services.product;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [HttpGet("{name}")]
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
            return Ok( products);
        }
        [HttpGet("BrandPagination")]
        public async Task<IActionResult> GetAllPaginationByBrand(int brandId ,int numOfProductPerPage,int pageNumber)
        {
            Pagination<List<GetAllProduct>> products = await _productServices.GetAllPaginationByBrand( brandId, numOfProductPerPage, pageNumber);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }

            return Ok(products);
        }[HttpGet("CategoryPagination")]
        public async Task<IActionResult> GetAllPaginationByCategory(int categoryId,int numOfProductPerPage,int pageNumber)
        {
            var products = await _productServices.GetAllPaginationByCategory(categoryId,numOfProductPerPage, pageNumber);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }[HttpGet("BrandAndCategoryPagination")]
        public async Task<IActionResult> GetAllPaginationByCategoryAndBrand(int categoryId, int brandId, int numOfProductPerPage,int pageNumber)
        {
            var products = await _productServices.GetAllPaginationByCategoryAndBrand(categoryId,brandId, numOfProductPerPage, pageNumber);
            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByBrandAndCategory(int id)
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
        [HttpGet("brandCount/{brandId}")]
        public async Task<IActionResult> GetCountByBrand(int brandId)=>Ok(await _productServices.GetCountByBrand(brandId));


        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> PostAsync([FromBody] CreatingAndUpdatingProduct product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.CreateProduct(product);
                return Ok(product);

            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CreatingAndUpdatingProduct product)
        {
            if (ModelState.IsValid)
            {
                await _productServices.UpdateProduct(product);
                return Ok(product);

            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (await _productServices.DeleteProduct(id) == null)
                return BadRequest();
            return Ok();
        }
    }
}
