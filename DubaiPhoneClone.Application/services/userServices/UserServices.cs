using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Application.services.User;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.userServices
{
    public class UserServices : IUserServices
    {
        IUserRepository _repo;
        public UserServices(IUserRepository repo) 
        {
            _repo = repo;        
        }

        public void AddCartItem(int bookId, int customerId, int quantity)
        {
           _repo.AddCartItem(bookId, customerId, quantity);
            _repo.Save();
        }

        public Models.User CreateUser(Models.User User)
        {
            var createuser=_repo.Create(User);
            _repo.Save();
            return createuser;
        }

        public Models.User DeleteUser(int UserId)
        {
            var deleteuser=_repo.Delete(UserId);
            _repo.Save();
            return deleteuser;
        }

        public IQueryable<Models.User> GetAllUser()
        {
            var query = _repo.GetAll();
            return query;
        }

        public IQueryable<Order> GetCustomerOrders(int userId)
        {
            var query=_repo.GetCustomerOrders(userId);
            return query;
        }

        public Models.User GetUserByID(int User)
        {
            var user=_repo.GetById(User);
            return user;
        }

        public Models.User UpdateUser(Models.User User)
        {
            var updateuser=_repo.Update(User);
            _repo.Save();
            return updateuser;
        }
    }
}
