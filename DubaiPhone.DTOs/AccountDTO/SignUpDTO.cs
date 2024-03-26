using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.AccountDTO
{
    public class SignUpDTO
    {
        [Required (ErrorMessage ="Username is Required")]
        public string Username { get; set; } = string.Empty;

        [Required (ErrorMessage ="Password is Required")]
        [MinLength (8,ErrorMessage ="Minumum length is 8")]
        [DataType (DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm password doen not match ")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


    }
}
