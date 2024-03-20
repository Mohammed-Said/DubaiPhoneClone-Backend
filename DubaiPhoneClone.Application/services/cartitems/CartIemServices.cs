using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.cartitems
{
    public class CartIemServices : ICartIemServices
    {
        ICartItemRepository _repo;
        public CartIemServices(ICartItemRepository repo) 
        {
            _repo = repo;
        }
        public async Task<CartItem> CreateCartItem(CartItem CartItem)
        {
            var cartItem =await _repo.Create(CartItem);
            await _repo.Save();
            return cartItem;
        }

        public async Task<CartItem> DeleteCartItem(int CartItemId)
        {
            var deltecart=await _repo.Delete(CartItemId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<CartItem>> GetAllCartItem()
        {
            var query =await _repo.GetAll(); 
            return query;
        }

        public async Task<CartItem> GetCartItemByID(int CartItem)
        {
            var element=await _repo.GetById(CartItem);
            return element;
        }

        public async Task<CartItem> UpdateCartItem(CartItem CartItem)
        {
            var updatecart=await _repo.Update(CartItem);
            await _repo.Save();
            return updatecart;
        }
    }
}
