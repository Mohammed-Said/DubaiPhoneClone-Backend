using DubaiPhone.DTOs.cartDTOs;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface ICartItemRepository : IRepository<CartItem, int>
    {
        bool ChangeQuantity(int CartItemId, int quantity);
        public Task<IQueryable<ProductCartDTO>> GetCartProducts(string userId);
        public Task<IQueryable<ProductCartDTO>> GetCartProducts(int[] ids);
        public Task<IQueryable<CartItem>> GetUserCart(string userId);
        Task<bool> AddCartItem(CartItem item);
        void PlaceOrder(Order order);
    }
}
