using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.wishlistitems
{
    public class WishListItems : IWishListItems
    {
        IWishlistItemRepository _repo;
        public WishListItems(IWishlistItemRepository repo)
        {
            _repo = repo;
        }

        public WishlistItem CreateWishlistItem(WishlistItem WishlistItem)
        {
            var createwish=_repo.Create(WishlistItem);
            _repo.Save();
            return createwish;
        }

        public WishlistItem DeleteWishlistItem(int WishlistItemId)
        {
            var deletewish= _repo.Delete(WishlistItemId);
            _repo.Save();
            return deletewish;
        }

        public IQueryable<WishlistItem> GetAllWishlistItem()
        {
            var query = _repo.GetAll();
            return query;
        }

        public IQueryable<Product> GetCustomerWishlist(int userId)
        {
            var query=_repo.GetCustomerWishlist(userId);
            return query;
        }

        public WishlistItem GetWishlistItemByID(int WishlistItem)
        {
            var wishlist=_repo.GetById(WishlistItem);
            return wishlist;
        }

        public WishlistItem UpdateWishlistItem(WishlistItem WishlistItem)
        {
            var updateWish=_repo.Update(WishlistItem);
            _repo.Save();
            return updateWish;
        }
    }
}
