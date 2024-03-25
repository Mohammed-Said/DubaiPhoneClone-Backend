

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiPhoneClone.Models
{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
       // public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        //public string Email { get; set; } = string.Empty;
        // public string Password { get; set; } = string.Empty;
        //public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public List<Order>? Orders { get; set; }
        public List<CartItem>? CartItems { get; set; }
        public List<Product>? Products { get; set; }

    }
}
