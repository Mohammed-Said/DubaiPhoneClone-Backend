using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.product
{
    public interface IProuductService
    {
         List<Product> GetAllProduct();

         Product GetProductByID(int Product);

         Product CreateProduct(Product Product);

         Product UpdateProduct(Product Product);

         Product DeleteProduct(int ProductId);
        
        List<Product> SearchName(string name);

        List<Product> GetByCategory(int cId);
        
        List<Product> GetByBrand(int bId);
        
        List<Product> GetByBrandAndCategory(int bId,int cId);
        
        bool ChangeStockQuantity(Product product, int quantity);

        int GetCountByCategory(int cId);
        
        int GetCountByBrand(int bId);

        List<Product> GetAllPagination(int Productnums, int PageNumber);
    }
}
