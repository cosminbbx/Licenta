using System;
using System.Collections.Generic;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.User.Dto;
using DataLayer.Entities;
using Omu.ValueInjecter;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DigitalEventPlaner.Services.Services.User
{
    public class UserService : IUserService
    {
        private IRepository<DataLayer.Entities.User> repository;
        private IUnitOfWork unit;
        public UserService(IRepository<DataLayer.Entities.User> repository,IUnitOfWork unit)
        {
            this.repository = repository;
            this.unit = unit;
        }

        public void Create(UserDto user)
        {
            if (user == null) throw new ArgumentNullException(nameof(UserDto));
            var userEntity = new DataLayer.Entities.User().InjectFrom(user) as DataLayer.Entities.User;
            userEntity.Password = HashPassword(user.Password);
            repository.Add(userEntity);
            unit.Commit();
        }

        private string HashPassword(string source)
        {
            MD5 md5Hash = MD5.Create();
            return GetMd5Hash(md5Hash, source);
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private bool IsCoreectPsssword(string input, string hash)
        {
            MD5 md5Hash = MD5.Create();
            return VerifyMd5Hash(md5Hash, input, hash);
        }

        private bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserDto> GetAll()
        {
            var userList = repository.GetAll();
            var userListDto = new List<UserDto>();
            foreach(var user in userList)
            {
                userListDto.Add(new UserDto().InjectFrom(user) as UserDto);
            }
            return userListDto;
        }

        public UserDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(UserDto));
            var user = repository.Query(x => x.Id == id).FirstOrDefault();
            return user == null ? null : new UserDto().InjectFrom(user) as UserDto;
        }

        public void SoftDelete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(UserDto));
            var user = repository.GetById(id);
            user.IsDeleted = true;
            repository.Update(user);
            unit.Commit();
        }

        public void Update(UserDto user)
        {
            if(user == null) throw new ArgumentNullException(nameof(UserDto));

            var userEntity = repository.GetById(user.Id).InjectFrom(user) as DataLayer.Entities.User;
            if (userEntity == null) throw new Exception($"Cannot update user with id = {user.Id}");
            repository.Update(userEntity);
            unit.Commit();
        }

        public UserDto GetByUsername(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return null;
            var user = repository.Query(x => x.UserName == userName).FirstOrDefault();
            if (user == null) return null;
            return new UserDto().InjectFrom(user) as UserDto;
        }

        public UserDto Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName)|| string.IsNullOrEmpty(password)) return null;
            var user = GetByUsername(userName);
            if (user == null) return null;
            var isCorrectPassword = IsCoreectPsssword(password, user.Password);
            if (isCorrectPassword) return user;
            return null;
        }
    }
}
