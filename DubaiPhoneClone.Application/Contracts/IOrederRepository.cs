using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        Task<Order?> CreateOrder(Order order);
        IQueryable<Order> GetUserOrders(string userId);

    }
}
