using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.wishlistitems
{
    public interface IWishListItems
    {
        public Task<IQueryable<WishlistItem>> GetAllWishlistItem();

        public Task<WishlistItem> GetWishlistItemByID(int WishlistItem);

        public Task<WishlistItem> CreateWishlistItem(WishlistItem WishlistItem);

        public Task<WishlistItem> UpdateWishlistItem(WishlistItem WishlistItem);

        public Task<WishlistItem> DeleteWishlistItem(int WishlistItemId);

        public IQueryable<Product> GetCustomerWishlist(int userId);
    }
}
