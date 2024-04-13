using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        private readonly ApplicationContext applicationContext;

        public CategoryRepository(ApplicationContext applicationContext) : base(applicationContext)=>
            this.applicationContext = applicationContext;

        public async Task<IQueryable<Category>> GetCategoryWithBrand() =>
            applicationContext.Categories.Include(c => c.Brands);
    }
}
