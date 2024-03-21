
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.services.Brands
{
    public interface IBrandServices
    {
        public Task<List<Brand>> GetAllBrand();

        public Task<Brand> GetBrandByID(int Brand);

        public Task<Brand> CreateBrand(Models.Brand Brand);

        public Task<Brand> UpdateBrand(Models.Brand Brand);

        public Task<Brand> DeleteBrand(int BrandId);
    }
}
