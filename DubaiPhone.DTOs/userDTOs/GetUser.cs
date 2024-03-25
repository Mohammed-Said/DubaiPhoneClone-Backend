using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.userDTOs
{
    public class GetUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Address { get; set; } 
        public string City { get; set; } 

        public List<Order>? Orders { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Product>? WishlistItems { get; set; }
    }
}
