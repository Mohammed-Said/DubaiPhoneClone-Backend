using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhone.DTOs.productDTOs
{
    public class GetAllProduct
    {

        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Percent { get; set; }
        public List<ProductImage>? Images { get; set; }
    }
}
