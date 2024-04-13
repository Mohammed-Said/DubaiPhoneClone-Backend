using AutoMapper;

using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.CouponDTOs;
using DubaiPhone.DTOs.OrderDTOs;
using DubaiPhone.DTOs.cartDTOs;

using DubaiPhone.DTOs.productDTOs;
using DubaiPhone.DTOs.userDTOs;
using DubaiPhoneClone.Models;


namespace DubaiPhoneClone.Application.mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, ProductDetailsDTO>().ForMember(d => d.Images, o => o.MapFrom(p => p.Images.Select(i=>i.Path)));
            CreateMap<Product, GetAllProduct>();
            CreateMap<Product,CreatingAndUpdatingProduct>().ReverseMap();

            
            //brand 
            CreateMap<Brand, BrandDto>();
            CreateMap<Brand, GetBrandDTO>();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap(); 
            CreateMap<Brand, BrandWithCategoryDTO>();
            
            //Category 
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryWithBrandDTOs>();

            //Orders
            CreateMap<Order, getOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();

            //Coupon
            CreateMap<Coupon, GetCouponDTO>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDTO>().ReverseMap();
            CreateMap<Coupon, CreateCouponDTO>().ReverseMap();

            //Cart
            CreateMap<CartItem, CreateCartItemDTO>().ReverseMap();
            CreateMap<CartItem, CartItemDTO>().ReverseMap();
            
            //User
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            CreateMap<User, GetUser>();

        }
    }
}
