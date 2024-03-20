using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.product
{
    public class productServices : IProuductService
    {
        IProductRepository _repo;
        public productServices(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> ChangeStockQuantity(Product product, int quantity)
        {
            var stock =await _repo.ChangeStockQuantity(product, quantity);
            return stock;
        }


        public async Task<Product> CreateProduct(Product Product)
        {
            var createproduct =await _repo.Create(Product);
            await _repo.Save();
            return createproduct;
        }

        public async Task<Product> DeleteProduct(int ProductId)
        {
            var delepro = await _repo.Delete(ProductId);
            await _repo.Save();
            return delepro;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            var products = await(await _repo.GetAll()).ToListAsync();
            return products;
        }

        public async Task<List<Product>> GetByBrand(int bramdId) =>
        await (await _repo.GetByBrand(bramdId)).ToListAsync();


        public async Task<List<Product>> GetByBrandAndCategory(int bId, int cId) =>
             await(await _repo.GetByBrandAndCategory(cId, bId)).ToListAsync();


        public async Task<List<Product>> GetByCategory(int cId) =>
            await(await _repo.GetByCategory(cId)).ToListAsync();


        public async Task<int> GetCountByBrand(int bId) =>
            await _repo.GetCountByBrand(bId);


        public async Task<int >GetCountByCategory(int cId) =>
            await _repo.GetCountByCategory(cId);


        public async Task<Product> GetProductByID(int Product) =>
           await _repo.GetById(Product);


        public async Task<List<Product>> SearchName(string name) =>
           await(await _repo.SearchName(name)).ToListAsync();


        public async Task<Product> UpdateProduct(Product Product) =>
             await _repo.Update(Product);


        public async Task<List<Product>> GetAllPagination(int Productnums, int PageNumber) =>
             await(await _repo.GetAll()).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync();

       
    }
}
