﻿using AutoMapper;
using DubaiPhone.DTOs.cartDTOs;
using DubaiPhone.DTOs.userDTOs;
using DubaiPhoneClone.Application.Contracts;
using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubaiPhoneClone.Application.services.userServices
{
    public class UserServices : IUserServices
    {
        IUserRepository _repo;
        IMapper _mapper;
        public UserServices(IUserRepository repo,IMapper  mapper) 
        {
            _repo = repo;     
            _mapper = mapper;
        }

        public async Task<bool> AddLovedItem(int itemId ,string userId)
        {
            bool sucess = await _repo.AddWishlistItem(itemId,userId);
            if (sucess)
            {
                await _repo.Save();
            }
            return sucess;
        }

        public async Task<GetUser> DeleteUser(int UserId)
        {
            var deleteuser= _mapper.Map<GetUser>(await _repo.Delete(UserId));
            await _repo.Save();
            return deleteuser;
        }


        public async Task<GetUser> GetUserByID(int User)
        {
            var user= _mapper.Map<GetUser>(await _repo.GetById(User));
            return user;
        }

        public async Task<GetUser> UpdateUser(UpdateUser User)
        {
            //  passwordHashing
            var updateuser=_mapper.Map<GetUser>(await _repo.Update(_mapper.Map<User>(User)));
            await _repo.Save();
            return updateuser;
        }
    }
}
