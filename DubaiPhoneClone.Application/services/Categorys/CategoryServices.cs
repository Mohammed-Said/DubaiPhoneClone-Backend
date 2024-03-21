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
        public CategoryServices(ICategoryRepository repo) { _repo = repo; }
        public async Task<Category> CreateCategory(Category Category)
        {
            var category = await _repo.Create(Category);
            await _repo.Save();
            return Category;
        }

        public async Task<Category> DeleteCategory(int CategoryId)
        {
            var deltecart = await _repo.Delete(CategoryId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<List<Category>>  GetAllCategory()
        {
            var query = await(await _repo.GetAll()).ToListAsync();
            return query;
        }

        public async Task<Category> GetCategoryByID(int Category)
        {
            var element = await _repo.GetById(Category);
            return element;
        }

        public async Task<Category> UpdateCategory(Category Category)
        {
            var updatecart = await _repo.Update(Category);
            await _repo.Save();
            return updatecart;
        }
    }
}
