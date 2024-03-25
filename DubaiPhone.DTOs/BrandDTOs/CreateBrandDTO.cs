using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.BrandDTOs
{
    public class CreateBrandDTO
    {
        public string Name { get; set; } = string.Empty;
        public string ArabicName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
