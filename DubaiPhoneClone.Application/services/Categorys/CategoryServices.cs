using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.Categorys
{
    public class CategoryServices
    {
        ICategoryRepository _repo;
        public CategoryServices(ICategoryRepository repo) { _repo = repo; }
        public Category CreateCategory(Category Category)
        {
            var category = _repo.Create(Category);
            _repo.Save();
            return Category;
        }

        public Category DeleteCategory(int CategoryId)
        {
            var deltecart = _repo.Delete(CategoryId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<Category> GetAllCategory()
        {
            var query = _repo.GetAll();
            return query;
        }

        public Category GetCategoryByID(int Category)
        {
            var element = _repo.GetById(Category);
            return element;
        }

        public Category UpdateCategory(Category Category)
        {
            var updatecart = _repo.Update(Category);
            _repo.Save();
            return updatecart;
        }
    }
}
