using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.Categorys
{
    public interface ICategoryServices
    {
        public Task<List<GetCategoryDTO>> GetAllCategory();

        public Task<GetCategoryDTO> GetCategoryByID(int Category);

        public Task<Category> CreateCategory(CreateCategoryDTO Category);

        public Task<Category> UpdateCategory(UpdateCategoryDTO Category);

        public Task<Category> DeleteCategory(int CategoryId);

        Task<List<CategoryWithBrandDTOs>> GetAllCategoryWithBrand();

    }
}
