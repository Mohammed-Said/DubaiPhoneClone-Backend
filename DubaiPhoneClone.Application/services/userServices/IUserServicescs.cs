using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.User
{
    public interface IUserServices
    {
        public IQueryable<Models.User> GetAllUser();

        public Models.User GetUserByID(int User);

        public Models.User CreateUser(Models.User User);

        public Models.User UpdateUser(Models.User User);

        public Models.User DeleteUser(int UserId);

        IQueryable<Order> GetCustomerOrders(int userId);

        void AddCartItem(int bookId, int customerId, int quantity);
    }
}
