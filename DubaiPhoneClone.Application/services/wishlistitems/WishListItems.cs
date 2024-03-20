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

        public async Task<WishlistItem> CreateWishlistItem(WishlistItem WishlistItem)
        {
            var createwish=await _repo.Create(WishlistItem);
            await _repo.Save();
            return createwish;
        }

        public async Task<WishlistItem> DeleteWishlistItem(int WishlistItemId)
        {
            var deletewish= await _repo.Delete(WishlistItemId);
            await _repo.Save();
            return deletewish;
        }

        public async Task<IQueryable<WishlistItem>> GetAllWishlistItem()
        {
            var query =await _repo.GetAll();
            return query;
        }

        public IQueryable<Product> GetCustomerWishlist(int userId)
        {
            var query=_repo.GetCustomerWishlist(userId);
            return query;
        }

        public async Task<WishlistItem> GetWishlistItemByID(int WishlistItem)
        {
            var wishlist=await _repo.GetById(WishlistItem);
            return wishlist;
        }

        public async Task<WishlistItem> UpdateWishlistItem(WishlistItem WishlistItem)
        {
            var updateWish=await _repo.Update(WishlistItem);
            await _repo.Save();
            return updateWish;
        }
    }
}
