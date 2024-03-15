using DubaiPhoneClone.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DubaiPhoneClone.Models;
using DubaiPhoneClone.Application.services.Brands;
namespace DubaiPhoneClone.Application.services.Brands
{
    public class BrandService : IBrandServices
    {
        IBrandRepository _repo;
        public BrandService(IBrandRepository  repo) 
        {
            _repo = repo;
        }

        public Brand CreateBrand(Models.Brand Brand)
        {
            var brand = _repo.Create(Brand);
            _repo.Save();
            return brand;
        }

        public Models.Brand DeleteBrand(int BrandId)
        {
            var deletbrand= _repo.Delete(BrandId);
            _repo.Save();
            return deletbrand;
        }

        public IQueryable<Models.Brand> GetAllBrand()
        {
            var brands=_repo.GetAll();
            return brands;
        }

        public Models.Brand GetBrandByID(int Brand)
        {
            var brand=_repo.GetById(Brand);
            return brand;
        }

        public Models.Brand UpdateBrand(Models.Brand Brand)
        {
            var brand= _repo.Update(Brand);
            _repo.Save();
            return brand;
        }
    }
}
