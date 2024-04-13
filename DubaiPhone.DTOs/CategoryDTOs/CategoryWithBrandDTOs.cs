using DubaiPhone.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.CategoryDTOs
{
    public class CategoryWithBrandDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string ImagePath { get; set; }

        public List<BrandDto> Brands { get; set; }
    }
}
