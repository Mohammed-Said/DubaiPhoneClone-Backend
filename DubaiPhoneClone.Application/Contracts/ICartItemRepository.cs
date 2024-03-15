using DubaiPhone.DTOs;
using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface ICartItemRepository : IRepository<CartItem, int>
    {
        bool ChangeQuantity(int CartItemId, int quantity);
        public IQueryable<ProductCart> GetUserCart(int userId);
        void PlaceOrder(Order order);
    }
}
