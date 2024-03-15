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
        IQueryable<Product> SearchName(string name);
        IQueryable<Product> GetByCategory(int categoryId);
        IQueryable<Product> GetByBrand(int brand);
        IQueryable<Product> GetByBrandAndCategory(int categoryId, int brand);
        bool ChangeStockQuantity(Product product, int quantity);
        int GetCountByCategory(int categoryId);
        int GetCountByBrand(int brand);
    }
}
