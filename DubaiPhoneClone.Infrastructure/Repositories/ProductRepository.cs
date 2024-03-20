using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, int> , IProductRepository
    {
        private readonly ApplicationContext applicationContext;

        public ProductRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public async Task<bool> ChangeStockQuantity(Product product, int quantity)
        {
            if (product == null)
                return false;

            // Ensure the resulting quantity is not negative
            if (product.Stock + quantity < 0)
                return false;

            // Update the stock quantity of the book
            product.Stock += quantity;

            // Save changes to persist the updated stock quantity
            await applicationContext.SaveChangesAsync();

            return true;
        }


        public async Task<IQueryable<Product>> GetByBrand(int brandId)=>
            applicationContext.Products.Where(p=>p.BrandId == brandId);


        public async Task<IQueryable<Product>> GetByBrandAndCategory(int categoryId, int brandId) =>
            applicationContext.Products.Where(p => p.BrandId == brandId && p.CategoryId == categoryId);
    

        public async Task<IQueryable<Product>> GetByCategory(int categoryId) =>
            applicationContext.Products.Where(p => p.CategoryId == categoryId);

        public async Task<int> GetCount() =>
            await   applicationContext.Products.CountAsync();
        public async Task<int> GetCountByBrand(int brandId) =>
            await applicationContext.Products.Where(p => p.BrandId == brandId).CountAsync();

        public async Task<int> GetCountByCategory(int categoryId) =>
          await  applicationContext.Products.Where(p => p.CategoryId == categoryId).CountAsync();

        public async Task<IQueryable<Product>> SearchName(string name)=>
            applicationContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

        
    }
}
