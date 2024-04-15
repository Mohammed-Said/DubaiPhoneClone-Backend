using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Models
{
    public enum OrderStatus
    {
        [EnumMember(Value = "pending")]
        pending,
        [EnumMember(Value = "Confirm")]
        Confirm,
        [EnumMember(Value = "Shipped")]
        Shipped, 
        [EnumMember(Value = "Delivered")]
        Delivered, 
        [EnumMember(Value = "Canceled")]
        Canceled,
        [EnumMember(Value = "Return")]
        Return,
    }
}
