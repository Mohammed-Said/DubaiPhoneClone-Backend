using AutoMapper;
using DubaiPhone.DTOs.cartDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.cartitems
{
    public class CartIemServices : ICartIemServices
    {
        ICartItemRepository _repo;
        private readonly IMapper _mapper;

        public CartIemServices(ICartItemRepository repo,IMapper mapper) 
        {
            _repo = repo;
            _mapper=mapper;
        }
        public async Task<CreateCartItemDTO> AddCartItem(CreateCartItemDTO item)
        {
            bool sucess = await _repo.AddCartItem(_mapper.Map<CartItem>(item));
            if (sucess)
            {
                await _repo.Save();
                return item;
            }
            return null;
        }

        public async Task<CartItem> DeleteCartItem(int CartItemId)
        {
            var deltecart=await _repo.Delete(CartItemId);
            await _repo.Save();
            return deltecart;
        }
        public async Task<CartItem> GetCartItemByID(int CartItem)
        {
            var element=await _repo.GetById(CartItem);
            return element;
        }

        public async Task<CartItem> UpdateCartItem(CartItem CartItem)
        {
            var updatecart=await _repo.Update(CartItem);
            await _repo.Save();
            return updatecart;
        }

        public async Task<List<CartItemDTO>> GetUserCart(string userId)=>
             _mapper.Map<List<CartItemDTO>>(await (await _repo.GetUserCart(userId)).ToListAsync());

        public async Task<List<ProductCartDTO>> GetCartProducts(string userId) =>
            await (await _repo.GetCartProducts(userId)).ToListAsync();
        public async Task<List<ProductCartDTO>> GetCartProducts(int[] ids) =>
            await (await _repo.GetCartProducts(ids)).ToListAsync();
    }
}
