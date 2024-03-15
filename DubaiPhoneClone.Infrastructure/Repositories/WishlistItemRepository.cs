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
    public class WishlistItemRepository : Repository<WishlistItem, int> , IWishlistItemRepository
    {
        private readonly ApplicationContext applicationContext;

        public WishlistItemRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public IQueryable<Product> GetCustomerWishlist(int userId)
        {
            return from item in applicationContext.WishlistItems
                   where item.UserId == userId
                   join prod in applicationContext.Products
                   on item.ProductId equals prod.Id
                   select prod;
        }
    }
}
