using DubaiPhoneClone.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubaiPhoneClone.Models;
using DubaiPhoneClone.Application.services.Brands;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DubaiPhone.DTOs.BrandDTOs;
namespace DubaiPhoneClone.Application.services.Brands
{
    public class BrandService : IBrandServices
    {
        IBrandRepository _repo;
        private readonly IMapper mapper;

        public BrandService(IBrandRepository  repo,IMapper mapper) 
        {
            _repo = repo;
            this.mapper = mapper;
        }

        public async Task<Brand> CreateBrand(CreateBrandDTO Brand)
        {
            var newBrand=mapper.Map<Brand>(Brand);
            var brand = await _repo.Create(newBrand);
            await _repo.Save();
            return brand;
        }

        public async Task<Brand> DeleteBrand(int BrandId)
        {
            var deletbrand= await _repo.Delete(BrandId);
            await _repo.Save();
            return deletbrand;
        }

        public async Task<List<GetBrandDTO>> GetAllBrand()
        {
            var brands=await(await _repo.GetAll()).ToListAsync();
            return mapper.Map<List<GetBrandDTO>>(brands);
        }

        public async Task<List<BrandWithCategoryDTO>> GetAllBrandWithCategory()
        {
            var brands= await (await _repo.GetBrandsWithCategory()).ToListAsync();
            return mapper.Map<List<BrandWithCategoryDTO>>(brands);
        }

        public async Task<GetBrandDTO> GetBrandByID(int Brand)
        {
            var brand=await _repo.GetById(Brand);
            return mapper.Map<GetBrandDTO>(brand);
        }

        public async Task<Brand> UpdateBrand(UpdateBrandDTO brand)
        {
            var oldBrand =await _repo.GetById(brand.Id);

            Brand updatedBrand = mapper.Map(brand,oldBrand);
            updatedBrand = await _repo.Update(updatedBrand);
            await _repo.Save();
            return updatedBrand;
        }
        
    }
}
