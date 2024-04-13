
using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.services.Brands
{
    public interface IBrandServices
    {
        public Task<List<GetBrandDTO>> GetAllBrand();

        public Task<GetBrandDTO> GetBrandByID(int Brand);

        public Task<Brand> CreateBrand(CreateBrandDTO Brand);

        public Task<Brand> UpdateBrand(UpdateBrandDTO Brand);

        public Task<Brand> DeleteBrand(int BrandId);
         Task<List<BrandWithCategoryDTO>> GetAllBrandWithCategory();

    }
}
