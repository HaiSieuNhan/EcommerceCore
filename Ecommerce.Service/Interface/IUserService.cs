using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;

namespace Ecommerce.Service.Interface
{
    public interface IUserService : IServices<User>
    {
        Task<UserDto> Register(UserDto user);
        Task<UserDto> Login(string username, string password);
        Task<bool> ActiveUser(string username);
        Task<UserDto> GetUserByUsername(string username);
    }
}
