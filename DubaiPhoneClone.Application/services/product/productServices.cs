using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
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
        public bool ChangeStockQuantity(Product product, int quantity)
        {
            var stock = _repo.ChangeStockQuantity(product, quantity);
            return stock;
        }


        public Product CreateProduct(Product Product)
        {
            var createproduct = _repo.Create(Product);
            _repo.Save();
            return createproduct;
        }

        public Product DeleteProduct(int ProductId)
        {
            var delepro = _repo.Delete(ProductId);
            _repo.Save();
            return delepro;
        }

        public List<Product> GetAllProduct()
        {
            var products = _repo.GetAll().ToList();
            return products;
        }

        public List<Product> GetByBrand(int bramdId) =>
         _repo.GetByBrand(bramdId).ToList();


        public List<Product> GetByBrandAndCategory(int bId, int cId) =>
             _repo.GetByBrandAndCategory(cId, bId).ToList();


        public List<Product> GetByCategory(int cId) =>
            _repo.GetByCategory(cId).ToList();


        public int GetCountByBrand(int bId) =>
            _repo.GetCountByBrand(bId);


        public int GetCountByCategory(int cId) =>
            _repo.GetCountByCategory(cId);


        public Product GetProductByID(int Product) =>
            _repo.GetById(Product);


        public List<Product> SearchName(string name) =>
            _repo.SearchName(name).ToList();


        public Product UpdateProduct(Product Product) =>
             _repo.Update(Product);


        public List<Product> GetAllPagination(int Productnums, int PageNumber) =>
             _repo.GetAll().Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToList();

       
    }
}
