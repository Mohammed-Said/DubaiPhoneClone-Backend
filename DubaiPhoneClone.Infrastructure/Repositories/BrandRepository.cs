using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
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
    }
}
