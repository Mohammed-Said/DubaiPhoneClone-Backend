using AutoMapper;
using DubaiPhone.DTOs.BrandDTOs;
using DubaiPhone.DTOs.CategoryDTOs;
using DubaiPhone.DTOs.OrderDTOs;
using DubaiPhone.DTOs.productDTOs;
using DubaiPhoneClone.Models;


namespace DubaiPhoneClone.Application.mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<Product, GetProductDetails>();
            CreateMap<Product, GetAllProduct>();
            CreateMap<Product,CreatingAndUpdatingProduct>().ReverseMap();
            
            //brand 
            CreateMap<Brand, GetBrandDTO>();
            CreateMap<Brand, UpdateBrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap(); 
            
            //Category 
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            //Orders
            CreateMap<Order, getOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();
            CreateMap<Order, CreateOrderDTO>().ReverseMap();

        }
    }
}
