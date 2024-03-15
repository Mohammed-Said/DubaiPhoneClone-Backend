using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IWishlistItemRepository : IRepository<WishlistItem, int>
    {
        public IQueryable<Product> GetCustomerWishlist(int userId);

    }
}
