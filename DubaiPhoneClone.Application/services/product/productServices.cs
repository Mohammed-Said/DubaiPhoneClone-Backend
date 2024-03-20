using AutoMapper;
using DubaiPhone.DTOs;
using DubaiPhone.DTOs.productDTOs;
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
        IMapper _mapper;
        public productServices(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<GetAllProduct>> GetAllProduct()
        {
            var products = await (await _repo.GetAll()).ToListAsync();
            List<GetAllProduct> result = _mapper.Map<List<GetAllProduct>>(products);
            return result;
        }
        public async Task<GetProductDetails> GetProductByID(int Product) =>
           _mapper.Map<GetProductDetails>(await _repo.GetById(Product));
        public async Task<List<GetAllProduct>> GetByBrand(int bramdId) =>
        _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrand(bramdId)).ToListAsync());
        public async Task<List<GetAllProduct>> GetByBrandAndCategory(int bId, int cId) =>
             _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrandAndCategory(cId, bId)).ToListAsync());
        public async Task<List<GetAllProduct>> GetByCategory(int cId) =>
           _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByCategory(cId)).ToListAsync());
        public async Task<List<GetAllProduct>> SearchName(string name) =>
           _mapper.Map<List<GetAllProduct>>(await (await _repo.SearchName(name)).ToListAsync());
        public async Task<Pagination<List<GetAllProduct>>> GetAllPagination(int Productnums, int PageNumber) =>
            (new Pagination<List<GetAllProduct>>()
            {
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetAll()).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Count = await _repo.GetCount(),
                Page = PageNumber,
                PageSize = Productnums
            });
        public async Task<int> GetCountByBrand(int bId) =>
            await _repo.GetCountByBrand(bId);
        public async Task<int> GetCountByCategory(int cId) =>
            await _repo.GetCountByCategory(cId);
        public async Task<CreatingAndUpdatingProduct> CreateProduct(CreatingAndUpdatingProduct Product)
        {
            Product prd = _mapper.Map<Product>(Product);
            var createdproduct = await _repo.Create(prd);
            await _repo.Save();
            Product = _mapper.Map<CreatingAndUpdatingProduct>(createdproduct);
            return Product;
        }
        public async Task<bool> ChangeStockQuantity(Product product, int quantity)
        {
            var stock = await _repo.ChangeStockQuantity(product, quantity);
            return stock;
        }
        public async Task<CreatingAndUpdatingProduct> UpdateProduct(CreatingAndUpdatingProduct Product){
            Product prd = _mapper.Map<Product>(Product);
            Product = _mapper.Map<CreatingAndUpdatingProduct>(await _repo.Update(prd));
            return Product;
        }
        public async Task<GetProductDetails> DeleteProduct(int ProductId)
        {
            var delepro = await _repo.Delete(ProductId);
            await _repo.Save();
            GetProductDetails res = _mapper.Map<GetProductDetails>(delepro);
            return res;
        }
    }
}
