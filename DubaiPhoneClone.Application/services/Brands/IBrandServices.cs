
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.services.Brands
{
    public interface IBrandServices
    {
        public IQueryable<Brand> GetAllBrand();

        public Brand GetBrandByID(int Brand);

        public Brand CreateBrand(Models.Brand Brand);

        public Brand UpdateBrand(Models.Brand Brand);

        public Brand DeleteBrand(int BrandId);
    }
}
