using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.Contracts
{
    public interface IWishlistRepository :IRepository<Wishlist,int>
    {
        Task Delete(Wishlist wishlistItem);
    }
}
