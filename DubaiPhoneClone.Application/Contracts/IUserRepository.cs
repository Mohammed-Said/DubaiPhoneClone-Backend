﻿using DubaiPhoneClone.Models;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<bool> AddWishlistItem(int prodId, string userId);
        Task<bool> CheckIfEmailIsUsedBefore(string  Email);
    }
}
