using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<List<Order>> GetCustomerOrders(int userId);
        Task<bool> AddWishlistItem(int prodId, int userId);
        Task<bool> CheckIfEmailIsUsedBefore(string  Email);
    }
}
