using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class WishlistRepository : Repository<Wishlist, int>, IWishlistRepository
    {
        private readonly ApplicationContext _appContext;

        public WishlistRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
            this._appContext = applicationContext;
        }

        public async new Task Delete(Wishlist wishlistItem)
        {
            _appContext.Wishlists.Remove(wishlistItem);
        }
        public  async new Task<IQueryable<Wishlist>> GetAll()
        {
            return _appContext.Wishlists;
        }
    }
}
