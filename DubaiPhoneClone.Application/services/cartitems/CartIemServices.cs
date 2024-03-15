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
        public CartItem CreateCartItem(CartItem CartItem)
        {
            var cartItem = _repo.Create(CartItem);
            _repo.Save();
            return cartItem;
        }

        public CartItem DeleteCartItem(int CartItemId)
        {
            var deltecart=_repo.Delete(CartItemId);
            _repo.Save();
            return deltecart;
        }

        public IQueryable<CartItem> GetAllCartItem()
        {
            var query = _repo.GetAll(); 
            return query;
        }

        public CartItem GetCartItemByID(int CartItem)
        {
            var element=_repo.GetById(CartItem);
            return element;
        }

        public CartItem UpdateCartItem(CartItem CartItem)
        {
            var updatecart=_repo.Update(CartItem);
            _repo.Save();
            return updatecart;
        }
    }
}
