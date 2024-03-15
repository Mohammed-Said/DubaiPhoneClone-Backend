using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.ProductImageServices
{
    public class ProductImageServices
    {
        private IProductImageRepository _repo;
        public ProductImageServices(IProductImageRepository repo)
        {
            _repo = repo;
        }
        public ProductImage CreateProductImage(ProductImage productImage)
        {
            var ProductImage = _repo.Create(productImage);
            _repo.Save();
            return ProductImage;
        }

        public ProductImage DeleteProductImage(int ProductImageId)
        {
            var deltecart = _repo.Delete(ProductImageId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<ProductImage> GetAllProductImage()
        {
            var query = _repo.GetAll();
            return query;
        }

        public ProductImage GetProductImageByID(int ProductImage)
        {
            var element = _repo.GetById(ProductImage);
            return element;
        }

        public ProductImage UpdateProductImage(ProductImage ProductImage)
        {
            var updatecart = _repo.Update(ProductImage);
            _repo.Save();
            return updatecart;
        }
    }
}
