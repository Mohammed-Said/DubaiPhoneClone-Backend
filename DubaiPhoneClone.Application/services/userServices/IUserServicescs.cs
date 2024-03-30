using DubaiPhone.DTOs.cartDTOs;
using DubaiPhone.DTOs.userDTOs;
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
        public Task<List<GetUser>> GetAllUser();

        public Task<GetUser> GetUserByID(int User);

        public Task<GetUser> CreateUser(CreateUser User);

        public Task<GetUser> UpdateUser(UpdateUser User);

        public Task<GetUser> DeleteUser(int UserId);

        Task<List<Order>> GetCustomerOrders(int userId);
        public  Task<bool> AddLovedItem(int itemId, int userId);

    }
}
