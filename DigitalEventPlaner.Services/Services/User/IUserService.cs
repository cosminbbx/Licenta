using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.User.Dto;

namespace DigitalEventPlaner.Services.Services.User
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        UserDto GetByUsername(string userName);
        UserDto Login(string userName, string password);
        void Create(UserDto user);
        void Update(UserDto user);
        void SoftDelete(int id);
    }
}
