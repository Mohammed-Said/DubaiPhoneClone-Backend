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
    public class OrederRepository : Repository<Order, int>, IOrderRepository
    {
        private readonly ApplicationContext applicationContext;

        public OrederRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        
    }
}
