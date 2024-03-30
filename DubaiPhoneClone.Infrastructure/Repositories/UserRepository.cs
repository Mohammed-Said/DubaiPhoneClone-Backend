using DubaiPhone.DTOs.cartDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Context;
using DubaiPhoneClone.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DubaiPhoneClone.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        //private readonly ApplicationContext applicationContext;

        public UserRepository(ApplicationContext applicationContext) : base(applicationContext) { }
        //this.applicationContext = applicationContext;

        public async Task<List<Order>> GetCustomerOrders(int userId) =>
          (await DbSetEntity.FindAsync(userId))?.Orders;

        public async Task<bool> AddWishlistItem(int prodId, int userId)
        {

            //List<WishlistItem> userLovedItems = (await DbSetEntity.FindAsync(userId))?.WishlistItems;
            //if(userLovedItems == null)
            //{
            //    return false;
            //}
            //var existingWishlistItem = userLovedItems.FirstOrDefault(c => c.ProductId == prodId && c.UserId == userId);
            //if (existingWishlistItem != null) 
            //    return  true;
            //var wishlistItem = new WishlistItem
            //{
            //    ProductId = prodId,
            //    UserId = userId

            //};
            //userLovedItems.Add(wishlistItem);
            return true;
            //applicationContext.SaveChanges();


        }

        public async Task<bool> CheckIfEmailIsUsedBefore(string Email)
        {
            User user = await DbSetEntity.Where(u => u.Email == Email).FirstOrDefaultAsync();
            if (user == null) return false;
            return true;
        }
    }
}
