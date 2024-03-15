using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.Contracts
{
    internal interface IProductRepository : IRepository<Product, int>
    {
        IQueryable<Product> SearchName(string name);
        IQueryable<Product> GetByCategory(string name);
        IQueryable<Product> GetByBrand(string name);
        IQueryable<Product> GetByBrandAndCategory(string name);
        bool ChangeStockQuantity(Product product, int quantity);
        bool CheckStockQuantity(Product product);
        int GetCountByCategory(string name);
        int GetCountByBrand(string name);
    }
}
