using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
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

        public bool ChangeStockQuantity(Product product, int quantity)
        {
            if (product == null)
                return false;

            // Ensure the resulting quantity is not negative
            if (product.Stock + quantity < 0)
                return false;

            // Update the stock quantity of the book
            product.Stock += quantity;

            // Save changes to persist the updated stock quantity
            applicationContext.SaveChanges();

            return true;
        }

  
        public IQueryable<Product> GetByBrand(int brandId)=>
            applicationContext.Products.Where(p=>p.BrandId == brandId);


        public IQueryable<Product> GetByBrandAndCategory(int categoryId, int brandId) =>
            applicationContext.Products.Where(p => p.BrandId == brandId && p.CategoryId == categoryId);
    

        public IQueryable<Product> GetByCategory(int categoryId) =>
            applicationContext.Products.Where(p => p.CategoryId == categoryId);

        public int GetCountByBrand(int brandId) =>
            applicationContext.Products.Where(p => p.BrandId == brandId).Count();

        public int GetCountByCategory(int categoryId) =>
            applicationContext.Products.Where(p => p.CategoryId == categoryId).Count();

        public IQueryable<Product> SearchName(string name)=>
            applicationContext.Products.Where(p => p.Name.ToLower().Contains(name.ToLower()));

        
    }
}
