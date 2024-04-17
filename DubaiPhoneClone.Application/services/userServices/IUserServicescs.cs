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

        public Task<GetUser> GetUserByID(int User);

        public Task<GetUser> UpdateUser(UpdateUser User);

        public Task<GetUser> DeleteUser(int UserId);

        public  Task<bool> AddLovedItem(int itemId, string userId);

    }
}
