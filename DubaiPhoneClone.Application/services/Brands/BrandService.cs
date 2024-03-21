using DubaiPhoneClone.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubaiPhoneClone.Models;
using DubaiPhoneClone.Application.services.Brands;
using Microsoft.EntityFrameworkCore;
namespace DubaiPhoneClone.Application.services.Brands
{
    public class BrandService : IBrandServices
    {
        IBrandRepository _repo;
        public BrandService(IBrandRepository  repo) 
        {
            _repo = repo;
        }

        public async Task<Brand> CreateBrand(Brand Brand)
        {
            var brand = await _repo.Create(Brand);
            await _repo.Save();
            return brand;
        }

        public async Task<Brand> DeleteBrand(int BrandId)
        {
            var deletbrand= await _repo.Delete(BrandId);
            await _repo.Save();
            return deletbrand;
        }

        public async Task<List<Brand>> GetAllBrand()
        {
            var brands=await(await _repo.GetAll()).ToListAsync();
            return brands;
        }

        public async Task<Brand> GetBrandByID(int Brand)
        {
            var brand=await _repo.GetById(Brand);
            return brand;
        }

        public async Task<Brand> UpdateBrand(Brand Brand)
        {
            var brand=await _repo.Update(Brand);
            await _repo.Save();
            return brand;
        }
    }
}
