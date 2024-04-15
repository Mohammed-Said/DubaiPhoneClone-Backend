using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.OrderDTOs
{
    public class CreateOrderDto
    {
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public string ShippingMethod { get; set; } = string.Empty;
        public string? Store { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string TransactionId { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        //User-Order one to many
        public string UserId { get; set; } = string.Empty;


    }
}
