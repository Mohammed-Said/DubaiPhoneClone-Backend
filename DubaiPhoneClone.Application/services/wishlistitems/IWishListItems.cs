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
        public IQueryable<WishlistItem> GetAllWishlistItem();

        public WishlistItem GetWishlistItemByID(int WishlistItem);

        public WishlistItem CreateWishlistItem(WishlistItem WishlistItem);

        public WishlistItem UpdateWishlistItem(WishlistItem WishlistItem);

        public WishlistItem DeleteWishlistItem(int WishlistItemId);

        public IQueryable<Product> GetCustomerWishlist(int userId);
    }
}
