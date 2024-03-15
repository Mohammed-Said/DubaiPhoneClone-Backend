using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IUserRepository : IRepository<User, int>
    {
        IQueryable<Order> GetCustomerOrders(int userId);
        void AddCartItem(int prodId, int userId, int quantity);
        void AddWishlistItem(int prodId, int userId, int quantity);
    }
}
