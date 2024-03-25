using AutoMapper;
using DubaiPhone.DTOs.cartDTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhone.DTOs.userDTOs;
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
            CreateMap<CartItem, CreateCartItem>().ReverseMap();
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            CreateMap<User, GetUser>();
        }
    }
}
