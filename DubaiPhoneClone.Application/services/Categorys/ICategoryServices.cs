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
        public IQueryable<Category> GetAllCategory();

        public Category GetCategoryByID(int Category);

        public Category CreateCategory(Category Category);

        public Category UpdateCategory(Category Category);

        public Category DeleteCategory(int CategoryId);
    }
}
