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
         Task<List<Product>> GetAllProduct();

        Task<Product> GetProductByID(int Product);

        Task<Product> CreateProduct(Product Product);

        Task<Product> UpdateProduct(Product Product);

        Task<Product> DeleteProduct(int ProductId);

        Task<List<Product>> SearchName(string name);

        Task<List<Product>> GetByCategory(int cId);

        Task<List<Product>> GetByBrand(int bId);

        Task<List<Product>> GetByBrandAndCategory(int bId,int cId);

        Task<bool> ChangeStockQuantity(Product product, int quantity);

        Task<int> GetCountByCategory(int cId);

        Task<int> GetCountByBrand(int bId);

        Task<List<Product>> GetAllPagination(int Productnums, int PageNumber);
    }
}
