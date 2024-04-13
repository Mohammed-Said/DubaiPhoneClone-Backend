using DubaiPhone.DTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.product
{
    public interface IProuductService
    {
        Task<List<GetAllProduct>> GetAllProduct();
        Task<List<ProductDetailsDTO>> GetProductDetails();

        Task<ProductDetailsDTO> GetProductByID(int Product);

        Task<CreatingAndUpdatingProduct> CreateProduct(CreatingAndUpdatingProduct Product);

        Task<CreatingAndUpdatingProduct> UpdateProduct(CreatingAndUpdatingProduct Product);

        Task<ProductDetailsDTO> DeleteProduct(int ProductId);

        Task<List<GetAllProduct>> SearchName(string name);

        Task<List<GetAllProduct>> GetByCategory(int cId);

        Task<List<GetAllProduct>> GetByBrand(int bId);

        Task<List<GetAllProduct>> GetByBrandAndCategory(int cId,int bId);


        Task<int> GetCountByCategory(int cId);

        Task<int> GetCountByBrand(int bId);

        Task<Pagination<List<GetAllProduct>>> GetAllPagination(int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrand(int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategory(int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrand(int categoryId, int brandId, int Productnums, int PageNumber);

        //order by  Pagination
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationOrderByPrice(string way, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationOrderByName(string way, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrandOrderByPrice(string way, int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrandOrderByName(string way, int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryOrderByName(string way, int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryOrderByPrice(string way, int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrandOrderByPrice(string way, int categoryId, int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrandOrderByName(string way, int categoryId, int brandId, int Productnums, int PageNumber);


        // Filter 
        Task<Pagination<List<GetAllProduct>>> FilterByPriceAllPagination(int min, int max, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByPriceBrandPagination(int min, int max, int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByPriceCategoryPagination(int min, int max, int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByPriceCategoryAndBrandPagination(int min, int max, int brandId, int categoryId, int Productnums, int PageNumber);

        Task<Pagination<List<GetAllProduct>>> FilterByStockAllPagination( int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByStockBrandPagination( int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByStockCategoryPagination( int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> FilterByStockCategoryAndBrandPagination( int categoryId, int brandId, int Productnums, int PageNumber);

        // min max price
        Task<decimal> GetMinPrice(int? categoryId, int? brandId);
        Task<decimal> GetMaxPrice(int? categoryId, int? brandId);
    }
}
