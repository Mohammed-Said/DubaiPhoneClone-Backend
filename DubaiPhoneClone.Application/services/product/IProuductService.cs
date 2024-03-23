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

        Task<GetProductDetails> GetProductByID(int Product);

        Task<CreatingAndUpdatingProduct> CreateProduct(CreatingAndUpdatingProduct Product);

        Task<CreatingAndUpdatingProduct> UpdateProduct(CreatingAndUpdatingProduct Product);

        Task<GetProductDetails> DeleteProduct(int ProductId);

        Task<List<GetAllProduct>> SearchName(string name);

        Task<List<GetAllProduct>> GetByCategory(int cId);

        Task<List<GetAllProduct>> GetByBrand(int bId);

        Task<List<GetAllProduct>> GetByBrandAndCategory(int bId,int cId);

        Task<bool> ChangeStockQuantity(Product product, int quantity);

        Task<int> GetCountByCategory(int cId);

        Task<int> GetCountByBrand(int bId);

        Task<Pagination<List<GetAllProduct>>> GetAllPagination(int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrand(int brandId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategory(int categoryId, int Productnums, int PageNumber);
        Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrand(int categoryId, int brandId, int Productnums, int PageNumber);

    }
}
