using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Task<IQueryable<Category>> GetCategoryWithBrand();

    }
}
