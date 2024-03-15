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
    public class CouponRepository : Repository<Coupon, int>, ICouponRepository
    {
        private readonly ApplicationContext applicationContext;

        public CouponRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
