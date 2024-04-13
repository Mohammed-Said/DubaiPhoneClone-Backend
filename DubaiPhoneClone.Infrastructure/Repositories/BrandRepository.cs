using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class BrandRepository : Repository<Brand, int>, IBrandRepository
    {
        ApplicationContext appContext;
        public BrandRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.appContext = applicationContext;
        }

        public async Task<IQueryable<Brand>> GetBrandsWithCategory() =>
            appContext.Brands.Include(b => b.Categories);

        
    }
}
