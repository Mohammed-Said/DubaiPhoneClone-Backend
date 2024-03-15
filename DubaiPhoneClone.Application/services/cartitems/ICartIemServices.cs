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
        public IQueryable<CartItem> GetAllCartItem();

        public CartItem GetCartItemByID(int CartItem);

        public CartItem CreateCartItem(CartItem CartItem);

        public CartItem UpdateCartItem(CartItem CartItem);

        public CartItem DeleteCartItem(int CartItemId);
    }
}
