using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.cartitems
{
    public interface ICartIemServices
    {
        public  Task<IQueryable<CartItem>> GetAllCartItem();

        public Task<CartItem> GetCartItemByID(int CartItem);

        public Task<CartItem> CreateCartItem(CartItem CartItem);

        public Task<CartItem> UpdateCartItem(CartItem CartItem);

        public Task<CartItem> DeleteCartItem(int CartItemId);
    }
}
