using AutoMapper;
using DubaiPhone.DTOs.cartDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
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
        public async Task<CreateCartItem> CreateCartItem(CreateCartItem CartItem)
        {
            var cartItem =_mapper.Map<CreateCartItem>(await _repo.Create(_mapper.Map<CartItem>(CartItem)));
            await _repo.Save();
            return cartItem;
        }

        public async Task<CartItem> DeleteCartItem(int CartItemId)
        {
            var deltecart=await _repo.Delete(CartItemId);
            await _repo.Save();
            return deltecart;
        }

        public async Task<IQueryable<CartItem>> GetAllCartItem()
        {
            var query =await _repo.GetAll(); 
            return query;
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
    }
}
