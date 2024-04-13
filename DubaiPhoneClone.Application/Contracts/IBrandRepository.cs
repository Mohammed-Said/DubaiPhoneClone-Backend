using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    
    public interface IBrandRepository : IRepository<Brand, int>
    {
        Task<IQueryable<Brand>> GetBrandsWithCategory();
    }
}
