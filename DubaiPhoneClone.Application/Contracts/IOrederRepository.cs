using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IOrederRepository : IRepository<Order, int>
    {
        bool ChangeStatus(Order order);

    }
}
