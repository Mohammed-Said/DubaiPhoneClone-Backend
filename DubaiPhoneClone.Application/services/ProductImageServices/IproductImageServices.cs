using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.ProductImageServices
{
    public interface IProductImageServices
    {
        Task<IQueryable<ProductImage>> GetAllProductImage();

         Task<ProductImage> GetProductImageByID(int ProductImage);

        Task<ProductImage> CreateProductImage(ProductImage ProductImage);

        Task<ProductImage> UpdateProductImage(ProductImage ProductImage);

        Task<ProductImage> DeleteProductImage(int ProductImageId);
    }
}
