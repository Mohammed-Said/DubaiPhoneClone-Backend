using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.ProductImageServices
{
    public class ProductImageServices :IProductImageServices
    {
        private IProductImageRepository _repo;
        public ProductImageServices(IProductImageRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProductImage> CreateProductImage(ProductImage productImage)
        {
            var ProductImage = await _repo.Create(productImage);
            await _repo.Save();
            return ProductImage;
        }

        public async Task<ProductImage> DeleteProductImage(int ProductImageId)
        {
            var deltecart = await _repo.Delete(ProductImageId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<ProductImage>>  GetAllProductImage()
        {
            var query = await _repo.GetAll();
            return query;
        }

        public async Task<ProductImage> GetProductImageByID(int ProductImage)
        {
            var element = await _repo.GetById(ProductImage);
            return element;
        }

        public async Task<ProductImage> UpdateProductImage(ProductImage ProductImage)
        {
            var updatecart = await _repo.Update(ProductImage);
            await _repo.Save();
            return updatecart;
        }
    }
}
