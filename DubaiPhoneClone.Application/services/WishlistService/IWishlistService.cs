using DubaiPhone.DTOs.WishlistDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.WishlistService
{
    public interface IWishlistService 
    {
         Task UpdateWishlist(int prodId, string userId);
         Task<List<WishlistDto>> GetWishlistItems(string userId);
    }
}
