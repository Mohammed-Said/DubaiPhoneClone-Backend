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
         IQueryable<ProductImage> GetAllProductImage();

         ProductImage GetProductImageByID(int ProductImage);

         ProductImage CreateProductImage(ProductImage ProductImage);

         ProductImage UpdateProductImage(ProductImage ProductImage);

         ProductImage DeleteProductImage(int ProductImageId);
    }
}
