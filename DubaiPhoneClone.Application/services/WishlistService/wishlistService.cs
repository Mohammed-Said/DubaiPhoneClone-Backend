using AutoMapper;
using DubaiPhone.DTOs.WishlistDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.WishlistService
{
    public class wishlistService : IWishlistService
    {

        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public wishlistService(
            IWishlistRepository wishlistRepository, 
            IProductRepository productRepository,
            IMapper mapper)
        {
            _wishlistRepository = wishlistRepository;
            _productRepository = productRepository;
            this._mapper = mapper;
        }
        public async Task UpdateWishlist(int prodId, string userId)
        {
            var item = await (await _wishlistRepository.GetAll())
                .Where(w => w.UserId == userId && w.ProductId == prodId)
                .FirstOrDefaultAsync();

            if (item is null) { 
            Wishlist wishListItem = new Wishlist()
            {
                ProductId = prodId,
                UserId = userId
            };
            await _wishlistRepository.Create(wishListItem);
            }else
            {
                _wishlistRepository?.Delete(item);
            }
            await _wishlistRepository?.Save();
        }

        public async Task<List<WishlistDto>> GetWishlistItems(string userId)
        {
            var items = await (await _wishlistRepository.GetAll()).Where(w => w.UserId == userId).ToListAsync();
            List<WishlistDto> wishlistPrd = new List<WishlistDto>();
            foreach (var item in items)
            {
                var prd = await _productRepository.GetById(item.ProductId);

                wishlistPrd.Add(_mapper.Map<WishlistDto>(prd));
            }
            return wishlistPrd;
        }
    }
}
