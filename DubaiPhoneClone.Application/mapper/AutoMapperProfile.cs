using AutoMapper;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, GetProductDetails>();
            CreateMap<Product, GetAllProduct>();
            CreateMap<Product,CreatingAndUpdatingProduct>().ReverseMap();
        }
    }
}
