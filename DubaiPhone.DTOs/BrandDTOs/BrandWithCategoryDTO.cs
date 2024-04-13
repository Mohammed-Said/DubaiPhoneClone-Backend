using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.BrandDTOs
{
    public class BrandWithCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string ArabicName { get; set; } 
        public string ImagePath { get; set; } 

        public List<CategoryDto> Categories { get; set; }
    }
}
