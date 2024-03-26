using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.AccountDTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = string.Empty;

    }
}
