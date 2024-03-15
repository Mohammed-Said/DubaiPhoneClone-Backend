using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IUserRepository : IRepository<User, int>
    {
        IQueryable<Order> GetCustomerOrders(int userId);
        void AddCartItem(int bookId, int customerId, int quantity);
    }
}
