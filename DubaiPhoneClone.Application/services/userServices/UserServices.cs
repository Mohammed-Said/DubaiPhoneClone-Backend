using DubaiPhoneClone.Application.Contracts;
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

        public async Task<User> CreateUser(User User)
        {
            var createuser=await _repo.Create(User);
            await _repo.Save();
            return createuser;
        }

        public async Task<User> DeleteUser(int UserId)
        {
            var deleteuser=await _repo.Delete(UserId);
            await _repo.Save();
            return deleteuser;
        }

        public async Task<IQueryable<User>>  GetAllUser()
        {
            var query = await _repo.GetAll();
            return query;
        }

        public IQueryable<Order> GetCustomerOrders(int userId)
        {
            var query=_repo.GetCustomerOrders(userId);
            return query;
        }

        public async Task<User> GetUserByID(int User)
        {
            var user=await _repo.GetById(User);
            return user;
        }

        public async Task<User> UpdateUser(User User)
        {
            var updateuser=await _repo.Update(User);
            await _repo.Save();
            return updateuser;
        }
    }
}
