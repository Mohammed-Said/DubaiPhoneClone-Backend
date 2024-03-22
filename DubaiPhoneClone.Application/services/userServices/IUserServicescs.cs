using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.userServices
{
    public interface IUserServices
    {
        public Task<IQueryable<User>> GetAllUser();

        public Task<User> GetUserByID(int User);

        public Task<User> CreateUser(User User);

        public Task<User> UpdateUser(User User);

        public Task<User> DeleteUser(int UserId);

        IQueryable<Order> GetCustomerOrders(int userId);

        void AddCartItem(int prodId, int customerId, int quantity);
    }
}
