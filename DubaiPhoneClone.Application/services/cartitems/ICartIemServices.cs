using DubaiPhone.DTOs.cartDTOs;
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
        public Task<CartItem> GetCartItemByID(int CartItem);

        Task<CreateCartItemDTO> AddCartItem(CreateCartItemDTO item);

        public Task<CartItem> UpdateCartItem(CartItem CartItem);

        public Task<CartItem> DeleteCartItem(int CartItemId);
        Task<List<CartItemDTO>> GetUserCart(string userId);
        Task<List<ProductCartDTO>> GetCartProducts(string userId);
        Task<List<ProductCartDTO>> GetCartProducts(int[] ids);
    }
}
