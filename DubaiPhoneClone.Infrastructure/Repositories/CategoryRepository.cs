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

        public async Task<IQueryable<GetCategoryWithBrandDTOs>> GetCategoryWithBrand() =>
            applicationContext.Categories.Include(c => c.Brands).Select(c => new GetCategoryWithBrandDTOs()
            {
                Id = c.Id,
                Name = c.Name,
                ImagePath = c.ImagePath,
                ArabicName = c.ArabicName,
                Brands = c.Brands.Select(b=>b.Name).ToList()

            });

        public async Task<IQueryable<Category>> SearchName(string name) =>
        applicationContext.Categories.Where(p => p.Name.ToLower().Contains(name.ToLower()));


    }
}
