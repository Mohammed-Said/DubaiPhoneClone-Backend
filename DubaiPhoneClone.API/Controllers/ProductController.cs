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
            _productServices = productImageServices;
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            var product = await _productServices.GetProductByID(id);
            if (product == null)
            {
                return NoContent();
            }
            return Ok(product);
        }

        [HttpPost]
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

       

        //[HttpGet]
        //public async Task<IActionResult> getALL()
        //{
        //    var products = await _productServices.GetAllProduct();
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("cat/{categoryId:int}")]
        //public async Task<IActionResult> getByCategory(int categoryId)
        //{
        //    var products = await _productServices.GetByCategory(categoryId);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("brand/{brandId:int}")]
        //public async Task<IActionResult> GetByBrand(int brandId)
        //{
        //    var products = await _productServices.GetByBrand(brandId);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(products);
        //}
        //[HttpGet("{categoryId:int}/{brandId:int}")]
        //public async Task<IActionResult> GetByBrandAndCategory(int categoryId, int brandId)
        //{
        //    var products = await _productServices.GetByBrandAndCategory(brandId, categoryId);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllProduct(int? categoryId, int? brandId)
        {
            List<GetAllProduct> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.GetByBrandAndCategory( categoryId.Value, brandId.Value));
            else if (categoryId.HasValue)
                products = (await _productServices.GetByCategory( categoryId.Value));

            else if (brandId.HasValue)
                products = (await _productServices.GetByBrand( brandId.Value));
            else
                products = await _productServices.GetAllProduct();



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

        #region GetPagination

        //[HttpGet("pages")]
        //public async Task<IActionResult> GetAllPagination(int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPagination(numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("BrandPagination")]
        //public async Task<IActionResult> GetAllPaginationByBrand(int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    Pagination<List<GetAllProduct>> products = await _productServices.GetAllPaginationByBrand(brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(products);
        //}
        //[HttpGet("CategoryPagination")]
        //public async Task<IActionResult> GetAllPaginationByCategory(int categoryId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategory(categoryId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("BrandAndCategoryPagination")]
        //public async Task<IActionResult> GetAllPaginationByCategoryAndBrand(int categoryId, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategoryAndBrand(categoryId, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
       
        [HttpGet("GetProductPagination")]
        public async Task<IActionResult> GetProductPagination(int? categoryId, int? brandId, int numOfProductPerPage, int pageNumber)
        {
            Pagination<List<GetAllProduct>> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.GetAllPaginationByCategoryAndBrand(categoryId.Value, brandId.Value, numOfProductPerPage, pageNumber));
            else if (categoryId.HasValue)
                products = (await _productServices.GetAllPaginationByCategory(categoryId.Value, numOfProductPerPage, pageNumber));

            else if (brandId.HasValue)
                products = (await _productServices.GetAllPaginationByBrand(brandId.Value, numOfProductPerPage, pageNumber));
            else
                products = await _productServices.GetAllPagination(numOfProductPerPage, pageNumber);



            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }

        #endregion

        #region OrderBy


        //[HttpGet("ProductPaginationOrderByPrice")]
        //public async Task<IActionResult> GetAllPaginationOrderByPrice(string way, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationOrderByPrice(way, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("ProductPaginationOrderByName")]
        //public async Task<IActionResult> GetAllPaginationOrderByName(string way, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationOrderByPrice(way, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByBrandOrderByName")]
        //public async Task<IActionResult> GetAllPaginationByBrandOrderByName(string way, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByBrandOrderByName(way, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByBrandOrderByPrice")]
        //public async Task<IActionResult> GetAllPaginationByBrandOrderByPrice(string way, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByBrandOrderByPrice(way, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByCategoryOrderByName")]
        //public async Task<IActionResult> GetAllPaginationByCategoryOrderByName(string way, int categoryId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategoryOrderByName(way, categoryId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByCategoryOrderByPrice")]
        //public async Task<IActionResult> GetAllPaginationByCategoryOrderByPrice(string way, int categoryId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategoryOrderByPrice(way, categoryId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByCategoryAndBrandOrderByPrice")]
        //public async Task<IActionResult> GetAllPaginationByCategoryAndBrandOrderByPrice(string way, int categoryId, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategoryAndBrandOrderByPrice(way, categoryId, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("ProductPaginationByCategoryAndBrandOrderByName")]
        //public async Task<IActionResult> GetAllPaginationByCategoryAndBrandOrderByName(string way, int categoryId, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.GetAllPaginationByCategoryAndBrandOrderByName(way, categoryId, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}


        [HttpGet("OrderByPrice")]
        public async Task<IActionResult> GetProductPaginationOrderByPrice(string way, int? categoryId, int? brandId, int numOfProductPerPage, int pageNumber)
        {

            Pagination<List<GetAllProduct>> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.GetAllPaginationByCategoryAndBrandOrderByPrice(way, categoryId.Value, brandId.Value, numOfProductPerPage, pageNumber));
            else if (categoryId.HasValue)
                products = (await _productServices.GetAllPaginationByCategoryOrderByPrice(way, categoryId.Value, numOfProductPerPage, pageNumber));

            else if (brandId.HasValue)
                products = (await _productServices.GetAllPaginationByBrandOrderByPrice(way, brandId.Value, numOfProductPerPage, pageNumber));
            else
                products = await _productServices.GetAllPaginationOrderByPrice(way, numOfProductPerPage, pageNumber);



            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        [HttpGet("OrderByName")]
        public async Task<IActionResult> GetProductPaginationOrderByName(string way, int? categoryId, int? brandId, int numOfProductPerPage, int pageNumber)
        {

            Pagination<List<GetAllProduct>> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.GetAllPaginationByCategoryAndBrandOrderByName(way, categoryId.Value, brandId.Value, numOfProductPerPage, pageNumber));
            else if (categoryId.HasValue)
                products = (await _productServices.GetAllPaginationByCategoryOrderByName(way, categoryId.Value, numOfProductPerPage, pageNumber));

            else if (brandId.HasValue)
                products = (await _productServices.GetAllPaginationByBrandOrderByName(way, brandId.Value, numOfProductPerPage, pageNumber));
            else
                products = await _productServices.GetAllPaginationOrderByName(way, numOfProductPerPage, pageNumber);



            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }


        #endregion

        #region FilterByPrice
        //[HttpGet("FilterAllByPrice")]
        //public async Task<IActionResult> FilterAllByPricePagination(int min, int max, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByPriceAllPagination(min, max, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("FilterBrandByPrice")]
        //public async Task<IActionResult> FilterBrandByPrice(int min, int max, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    Pagination<List<GetAllProduct>> products = await _productServices.FilterByPriceBrandPagination(min, max, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(products);
        //}
        //[HttpGet("FilterCategoryByPrice")]
        //public async Task<IActionResult> FilterCategoryByPrice(int min, int max, int categoryId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByPriceCategoryPagination(min, max, categoryId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("FilterCategoryAndBrandByPrice")]
        //public async Task<IActionResult> FilterCategoryAndBrandByPrice(int min, int max, int categoryId, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByPriceCategoryAndBrandPagination(min, max, categoryId, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        [HttpGet("FilterByPrice")]
        public async Task<IActionResult> FilterByPrice(int min, int max, int? categoryId, int? brandId, int numOfProductPerPage, int pageNumber)
        {
            Pagination<List<GetAllProduct>> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.FilterByPriceCategoryAndBrandPagination(min,max,categoryId.Value, brandId.Value, numOfProductPerPage, pageNumber));
            else if (categoryId.HasValue)
                products = (await _productServices.FilterByPriceCategoryPagination(min,max,categoryId.Value, numOfProductPerPage, pageNumber));

            else if (brandId.HasValue)
                products = (await _productServices.FilterByPriceCategoryPagination(min,max,brandId.Value, numOfProductPerPage, pageNumber));
            else
                products = await _productServices.FilterByPriceAllPagination(min,max,numOfProductPerPage, pageNumber);



            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }

        #endregion

        #region FilterByStock

        //[HttpGet("FilterAllByStock")]
        //public async Task<IActionResult> FilterAllByStock(int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByStockAllPagination(numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        //[HttpGet("FilterBrandByStock")]
        //public async Task<IActionResult> FilterBrandByStock(int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    Pagination<List<GetAllProduct>> products = await _productServices.FilterByStockBrandPagination(brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(products);
        //}
        //[HttpGet("FilterCategoryByStock")]
        //public async Task<IActionResult> FilterCategoryByStock(int categoryId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByStockCategoryPagination(categoryId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}
        //[HttpGet("FilterCategoryAndBrandByStock")]
        //public async Task<IActionResult> FilterCategoryAndBrandByStock(int categoryId, int brandId, int numOfProductPerPage, int pageNumber)
        //{
        //    var products = await _productServices.FilterByStockCategoryAndBrandPagination(categoryId, brandId, numOfProductPerPage, pageNumber);
        //    if (products == null || products.Count == 0)
        //    {
        //        return NoContent();
        //    }
        //    return Ok(products);
        //}

        [HttpGet("FilterByStock")]
        public async Task<IActionResult> FilterByStock(int? categoryId, int? brandId, int numOfProductPerPage, int pageNumber)
        {
            Pagination<List<GetAllProduct>> products;

            if (categoryId.HasValue && brandId.HasValue)
                products = (await _productServices.FilterByStockCategoryAndBrandPagination(categoryId.Value, brandId.Value, numOfProductPerPage, pageNumber));
            else if (categoryId.HasValue)
                products = (await _productServices.FilterByStockCategoryPagination(categoryId.Value, numOfProductPerPage, pageNumber));

            else if (brandId.HasValue)
                products = (await _productServices.FilterByStockBrandPagination(brandId.Value, numOfProductPerPage, pageNumber));
            else
                products = await _productServices.FilterByStockAllPagination(numOfProductPerPage, pageNumber);



            if (products == null || products.Count == 0)
            {
                return NoContent();
            }
            return Ok(products);
        }

        #endregion

        #region Min&MaxPrice
        [HttpGet("MinPrice")]
        public async Task<IActionResult> MinPrice(int? categoryId, int? brandId)
        {
            var products = await _productServices.GetMinPrice(categoryId, brandId);

            return Ok(products);
        }
        [HttpGet("MaxPrice")]
        public async Task<IActionResult> MaxPrice(int? categoryId, int? brandId)
        {
            var products = await _productServices.GetMaxPrice(categoryId, brandId);

            return Ok(products);
        }
        #endregion

        [HttpGet("catCount/{catId}")]
        public async Task<IActionResult> GetCountByCategory(int catId) => Ok(await _productServices.GetCountByCategory(catId));
        [HttpGet("brandCount/{brandId}")]
        public async Task<IActionResult> GetCountByBrand(int brandId) => Ok(await _productServices.GetCountByBrand(brandId));

    }
}
