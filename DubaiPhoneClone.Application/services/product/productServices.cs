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

        public async Task<CreatingAndUpdatingProduct> CreateProduct(CreatingAndUpdatingProduct Product)
        {
            Product prd = _mapper.Map<Product>(Product);
            var createdproduct = await _repo.Create(prd);
            await _repo.Save();
            Product = _mapper.Map<CreatingAndUpdatingProduct>(createdproduct);
            return Product;
        }
        public async Task<CreatingAndUpdatingProduct> UpdateProduct(CreatingAndUpdatingProduct Product)
        {
            Product prd = _mapper.Map<Product>(Product);
            Product = _mapper.Map<CreatingAndUpdatingProduct>(await _repo.Update(prd));
            return Product;
        }
        public async Task<ProductDetailsDTO> DeleteProduct(int ProductId)
        {
            var delepro = await _repo.Delete(ProductId);
            await _repo.Save();
            ProductDetailsDTO res = _mapper.Map<ProductDetailsDTO>(delepro);
            return res;
        }
        public async Task<List<GetAllProduct>> GetAllProduct()
        {
            var products = await (await _repo.GetAll()).ToListAsync();
            List<GetAllProduct> result = _mapper.Map<List<GetAllProduct>>(products);
            return result;
        }
        // ===========
        public async Task<List<ProductDetailsDTO>> GetProductDetails()
        {
            var products = await(await _repo.GetAll()).ToListAsync();
            List<ProductDetailsDTO> result = _mapper.Map< List < ProductDetailsDTO >>(products);
            return result;
        }
       

        public async Task<ProductDetailsDTO> GetProductByID(int Product) =>
           _mapper.Map<ProductDetailsDTO>(await _repo.GetById(Product));

        public async Task<List<GetAllProduct>> GetByBrand(int bramdId) =>
        _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrand(bramdId)).ToListAsync());
        public async Task<List<GetAllProduct>> GetByBrandAndCategory( int cId, int bId) =>
             _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrandAndCategory(cId, bId)).ToListAsync());
        public async Task<List<GetAllProduct>> GetByCategory(int cId) =>
           _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByCategory(cId)).ToListAsync());

        public async Task<List<GetAllProduct>> SearchName(string name) =>
           _mapper.Map<List<GetAllProduct>>(await (await _repo.SearchName(name)).ToListAsync());
        
        public async Task<int> GetCountByBrand(int bId) =>
            await _repo.GetCountByBrand(bId);
        public async Task<int> GetCountByCategory(int cId) =>
            await _repo.GetCountByCategory(cId); 
        public async Task<int> GetCountByCategoryAndBrand(int categoryId,int brandId) =>
            await _repo.GetCountByCategoryAndBrand(categoryId,brandId);
        
       


        #region Pagination
        public async Task<Pagination<List<GetAllProduct>>> GetAllPagination(int Productnums, int PageNumber) =>
           (new Pagination<List<GetAllProduct>>()
           {
               Count = await _repo.GetCount(),
               Page = PageNumber,
               PageSize = Productnums,
               entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetAll()).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
               Stock = await GetCountByAllStock()
           });
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrand(int brandId, int Productnums, int PageNumber) =>
            (new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByBrand(brandId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrand(brandId)).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByBrandStock(brandId)

            });

        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategory(int categoryId, int Productnums, int PageNumber) =>
            (new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByCategory(categoryId)).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryStock(categoryId)

            });

        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrand(int categoryId, int brandId, int Productnums, int PageNumber) =>
            (new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrandAndCategory(categoryId, brandId)).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryAndBrandStock(categoryId, brandId)
            }); 
        #endregion

        #region Order By 

        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationOrderByPrice( string way, int Productnums, int PageNumber)
        {
            var query =  (await _repo.GetAll());

            if (way.ToUpper() == "ASC")
                query =  query.OrderBy(p=>p.SalePrice);
            else
                query = query.OrderByDescending(p=>p.SalePrice);

            return new Pagination<List<GetAllProduct>>()
            {
                entity = _mapper.Map<List<GetAllProduct>>((await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync())),
                Count = query.Count(),
                Page = PageNumber,
                PageSize = PageNumber,
                Stock = await GetCountByAllStock()


            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationOrderByName( string way, int Productnums, int PageNumber)
        {
            var query =  (await _repo.GetAll());

            if (way.ToUpper() == "ASC")
                query =  query.OrderBy(p=>p.Name);
            else
                query = query.OrderByDescending(p=>p.Name);

            return new Pagination<List<GetAllProduct>>()
            {
                entity = _mapper.Map<List<GetAllProduct>>((await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync())),
                Count = query.Count(),
                Page = PageNumber,
                PageSize = PageNumber,
                Stock = await GetCountByAllStock()


            };
        }

        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrandOrderByPrice(string way, int brandId, int Productnums, int PageNumber) {
            var query = await _repo.GetByBrand(brandId);

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.SalePrice);
            else
                query = query.OrderByDescending(p => p.SalePrice);

            return new Pagination<List<GetAllProduct>>()
           {
               Count = await _repo.GetCountByBrand(brandId),
               Page = PageNumber,
               PageSize = Productnums,
               entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByBrandStock(brandId)

            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByBrandOrderByName(string way, int brandId, int Productnums, int PageNumber) {
            var query = await _repo.GetByBrand(brandId);

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.Name);
            else
                query = query.OrderByDescending(p => p.Name);

            return new Pagination<List<GetAllProduct>>()
           {
               Count = await _repo.GetCountByBrand(brandId),
               Page = PageNumber,
               PageSize = Productnums,
               entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByBrandStock(brandId)

            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryOrderByName(string way, int categoryId, int Productnums, int PageNumber) {
            var query = (await _repo.GetByCategory(categoryId));

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.Name);
            else
                query = query.OrderByDescending(p => p.Name);

            return new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryStock(categoryId)

            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryOrderByPrice(string way, int categoryId, int Productnums, int PageNumber) {
            var query = (await _repo.GetByCategory(categoryId));

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.SalePrice);
            else
                query = query.OrderByDescending(p => p.SalePrice);

            return new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryStock(categoryId)

            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrandOrderByPrice(string way, int categoryId,int brandId, int Productnums, int PageNumber) {
            var query = (await _repo.GetByBrandAndCategory(categoryId,brandId));

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.SalePrice);
            else
                query = query.OrderByDescending(p => p.SalePrice);

            return new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategoryAndBrand(categoryId,brandId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryAndBrandStock(categoryId, brandId)

            };
        }
        public async Task<Pagination<List<GetAllProduct>>> GetAllPaginationByCategoryAndBrandOrderByName(string way, int categoryId,int brandId, int Productnums, int PageNumber) {
            var query = (await _repo.GetByBrandAndCategory(categoryId,brandId));

            if (way.ToUpper() == "ASC")
                query = query.OrderBy(p => p.Name);
            else
                query = query.OrderByDescending(p => p.Name);

            return new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategoryAndBrand(categoryId,brandId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await query.Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryAndBrandStock(categoryId, brandId)

            };
        }

        #endregion

        #region Filter By Price
        public async Task<Pagination<List<GetAllProduct>>> FilterByPriceAllPagination(int min, int max, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCount(),
                Page = PageNumber,
                PageSize = Productnums,
                Stock = await GetCountByAllStock(),
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetAll()).Where(p => p.SalePrice >= min && p.SalePrice <= max).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        public async Task<Pagination<List<GetAllProduct>>> FilterByPriceBrandPagination(int min, int max, int brandId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByBrand(brandId),
                Page = PageNumber,
                PageSize = Productnums,
                Stock = await GetCountByBrandStock(brandId),

                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrand(brandId)).Where(p => p.SalePrice >= min && p.SalePrice <= max).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        public async Task<Pagination<List<GetAllProduct>>> FilterByPriceCategoryPagination(int min, int max, int categoryId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                Stock = await GetCountByCategoryStock(categoryId),

                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByCategory(categoryId)).Where(p => p.SalePrice >= min && p.SalePrice <= max).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        public async Task<Pagination<List<GetAllProduct>>> FilterByPriceCategoryAndBrandPagination(int min, int max, int brandId, int categoryId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategoryAndBrand(categoryId, brandId),
                Page = PageNumber,
                PageSize = Productnums,
                Stock = await GetCountByCategoryAndBrandStock(categoryId, brandId),
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrandAndCategory(categoryId, brandId)).Where(p => p.SalePrice >= min && p.SalePrice <= max).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        #endregion


        public async Task<int> GetCountByAllStock()=>
            (await _repo.GetAll()).Where(p => p.Stock > 0).Count();
        public async Task<int> GetCountByBrandStock(int brandId)=>
            (await _repo.GetByBrand(brandId)).Where(p => p.Stock > 0).Count();
        public async Task<int> GetCountByCategoryStock(int categoryId)=>
            (await _repo.GetByCategory(categoryId)).Where(p => p.Stock > 0).Count();
        public async Task<int> GetCountByCategoryAndBrandStock(int categoryId,int brandId)=>
            (await _repo.GetByBrandAndCategory(categoryId,brandId)).Where(p => p.Stock > 0).Count();

        #region Filter By Stock
        public async Task<Pagination<List<GetAllProduct>>> FilterByStockAllPagination(int Productnums, int PageNumber) =>
           new Pagination<List<GetAllProduct>>()
           {
               Count = await _repo.GetCount(),
               Page = PageNumber,
               PageSize = Productnums,
               entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetAll()).Where(p => p.Stock > 0).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
               Stock = await GetCountByAllStock()

           };
        public async Task<Pagination<List<GetAllProduct>>> FilterByStockBrandPagination(int brandId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByBrand(brandId),
                Page = PageNumber,
                PageSize = Productnums,
                Stock = await GetCountByBrandStock(brandId),
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrand(brandId)).Where(p => p.Stock > 0).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        public async Task<Pagination<List<GetAllProduct>>> FilterByStockCategoryPagination(int categoryId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Stock = await GetCountByCategoryStock(categoryId),
                Count = await _repo.GetCountByCategory(categoryId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByCategory(categoryId)).Where(p => p.Stock > 0).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
            };
        public async Task<Pagination<List<GetAllProduct>>> FilterByStockCategoryAndBrandPagination(int brandId, int categoryId, int Productnums, int PageNumber) =>
            new Pagination<List<GetAllProduct>>()
            {
                Count = await _repo.GetCountByCategoryAndBrand(categoryId, brandId),
                Page = PageNumber,
                PageSize = Productnums,
                entity = _mapper.Map<List<GetAllProduct>>(await (await _repo.GetByBrandAndCategory(categoryId, brandId)).Where(p => p.Stock > 0).Skip(Productnums * (PageNumber - 1)).Take(Productnums).ToListAsync()),
                Stock = await GetCountByCategoryAndBrandStock(categoryId, brandId)

            };


        #endregion

        public async Task<decimal> GetMinPrice(int? categoryId,int? brandId)
        {
            if (categoryId.HasValue&&brandId.HasValue)
               return (await _repo.GetByBrandAndCategory(categoryId.Value,brandId.Value)).Min(p => p.SalePrice);
            if (categoryId.HasValue)
               return (await _repo.GetByCategory(categoryId.Value)).Min(p => p.SalePrice);
            if (brandId.HasValue)
               return (await _repo.GetByBrand(brandId.Value)).Min(p => p.SalePrice);
            

            return (await _repo.GetAll()).Min(p => p.SalePrice);


        }
        public async Task<decimal> GetMaxPrice() =>
            (await _repo.GetAll()).Max(p => p.SalePrice);

        public async Task<decimal> GetMaxPrice(int? categoryId, int? brandId)
        {
            if (categoryId.HasValue && brandId.HasValue)
                return (await _repo.GetByBrandAndCategory(categoryId.Value, brandId.Value)).Max(p => p.SalePrice);
            if (categoryId.HasValue)
                return (await _repo.GetByCategory(categoryId.Value)).Max(p => p.SalePrice);
            if (brandId.HasValue)
                return (await _repo.GetByBrand(brandId.Value)).Max(p => p.SalePrice);

            return (await _repo.GetAll()).Max(p => p.SalePrice);
        }
    }
}
