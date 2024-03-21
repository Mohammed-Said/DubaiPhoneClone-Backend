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
        public Task<List<Category>> GetAllCategory();

        public Task<Category> GetCategoryByID(int Category);

        public Task<Category> CreateCategory(Category Category);

        public Task<Category> UpdateCategory(Category Category);

        public Task<Category> DeleteCategory(int CategoryId);
    }
}
