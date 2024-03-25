using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Task<IQueryable<Product>>  SearchName(string name);
        Task<IQueryable<Product>> GetByCategory(int categoryId);
        Task<IQueryable<Product>> GetByBrand(int brand);
        Task<IQueryable<Product>> GetByBrandAndCategory(int categoryId, int brand);
        Task<int> GetCountByCategoryAndBrand(int categoryId, int brandId);
        Task<int> GetCountByCategory(int categoryId);
        Task<int> GetCountByBrand(int brand);
        Task<int> GetCount();
    }
}
