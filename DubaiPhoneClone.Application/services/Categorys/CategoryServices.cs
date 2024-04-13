using AutoMapper;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.Categorys
{
    public class CategoryServices:ICategoryServices
    {
        ICategoryRepository _repo;
        private readonly IMapper mapper;

        public CategoryServices(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        public async Task<Category> CreateCategory(CreateCategoryDTO Category)
        {
            var newCategory = mapper.Map<Category>(Category);

            var category = await _repo.Create(newCategory);
            await _repo.Save();
            return category;
        }

        public async Task<Category> DeleteCategory(int CategoryId)
        {
            var oldCategory = await _repo.GetById(CategoryId);

            if (oldCategory is null)
                return null;
            var deltecart = await _repo.Delete(CategoryId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<List<GetCategoryDTO>>  GetAllCategory()
        {
            var categories = await(await _repo.GetAll()).ToListAsync();
            return mapper.Map<List<GetCategoryDTO>>(categories);
        }

        public async Task<List<CategoryWithBrandDTOs>> GetAllCategoryWithBrand()
        {
            var categories= await (await _repo.GetCategoryWithBrand()).ToListAsync();
            return mapper.Map< List<CategoryWithBrandDTOs>>(categories);
        }

        public async Task<GetCategoryDTO> GetCategoryByID(int Category)
        {
            var category = await _repo.GetById(Category);
            return mapper.Map<GetCategoryDTO>(category);

        }

        public async Task<Category> UpdateCategory(UpdateCategoryDTO category)
        {
            var oldCategory = await _repo.GetById(category.Id);
            if (oldCategory is null)
                return null;
            Category newCategory = mapper.Map(category,oldCategory);

            var updatecart = await _repo.Update(newCategory);
            await _repo.Save();
            return updatecart;
        }
    }
}
